using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolyMesh
{
    internal static class Geometry
    {
        public static float kd = 1;
        public static float ks = 1;
        public static Color il = Color.FromArgb(255,255,255);
        public static Color io = Color.Blue;
        public static int m = 20;
        public static float Z = 500 + Settings.bitmapSize / 2;
        private static Vector3 startLight = new Vector3(Settings.bitmapSize / 2, Settings.bitmapSize / 2, Settings.bitmapSize / 2);
        public static Vector3 GetLightVector(float span)
        {
            //return new Vector3(startLight.X + (float)(Math.Sin(span) * startLight.X), startLight.Y + (float)(Math.Cos(span) * startLight.Y), Z);
            return new Vector3(startLight.X + (float)(Math.Sin(span) * Math.Sin(span / 5) * startLight.X), startLight.Y + (float)(Math.Cos(span) * Math.Sin(span / 5) * startLight.Y), Z);
        }
        public static Color GetColor(Vector3 source, Vector3 normal)
        {
            var R = normal * Vector3.Dot(normal, source) * 2 - source;
            var V = new Vector3(0, 0, 1);
            float sp2 = Vector3.Dot(Vector3.Normalize(R), V);
            float sp1 = Vector3.Dot(Vector3.Normalize(normal), Vector3.Normalize(source));
            sp1 = sp1 > 0 ? sp1 : 0;
            sp2 = sp2 > 0 ? sp2 : 0;
            sp1 *= kd/255;
            sp2 = (float)Math.Pow(sp2, m) * ks/255;
            int colorR = (int)(il.R * io.R * sp1 + il.R * io.R * sp2);
            int colorG = (int)(il.G * io.G * sp1 + il.G * io.G * sp2);
            int colorB = (int)(il.B * io.B * sp1 + il.B * io.B * sp2);
            colorR = colorR > 255 ? 255 : colorR < 0 ? 0 : colorR;
            colorG = colorG > 255 ? 255 : colorG < 0 ? 0 : colorG;
            colorB = colorB > 255 ? 255 : colorB < 0 ? 0 : colorB;
            return Color.FromArgb(colorR, colorG, colorB);
        }
        public static double ScalarProduct(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        public static Vector3 Normalise(Vector3 v)
        {
            double div = 1 / Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
            return v * (float)div;
        }
        public static (float w1,float w2,float w3) GetBarycentricWeights(Vector3[] positions, float x, float y)
        {
            float div = (positions[1].Y - positions[2].Y) * (positions[0].X - positions[2].X) + (positions[2].X - positions[1].X) * (positions[0].Y - positions[2].Y);
            float w1 = (positions[1].Y - positions[2].Y) * (x - positions[2].X) + (positions[2].X - positions[1].X) * (y - positions[2].Y);
            float w2 = (positions[2].Y - positions[0].Y) * (x - positions[2].X) + (positions[0].X - positions[2].X) * (y - positions[2].Y);
            w1 /= div;
            w2 /= div;
            float w3 = 1 - w1 - w2;
            return (w1, w2, w3);
        }
        public static Vector3 NormalMapMultiplication(Vector3 normal, Color color)
        {
            Vector3 tex = new Vector3((float)color.R / 128 - 1, (float)color.G / 128 - 1, (float)color.B / 256);
            Vector3 binormal;
            if(normal.X == 0 && normal.Y == 0 && normal.Z == 1)
            {
                binormal = new Vector3(0f, 1f, 0f);
            }
            else
            {
                binormal = Vector3.Cross(normal, new Vector3(0f, 0f, 1f));
            }
            Vector3 tangent = Vector3.Cross(binormal, normal);
            return new Vector3(Vector3.Dot(tex, tangent), Vector3.Dot(tex, binormal), Vector3.Dot(tex, normal));
        }
    }
}
