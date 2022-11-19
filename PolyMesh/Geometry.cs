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
        public static double kd = 1;
        public static double ks = 1;
        public static Color il = Color.FromArgb(255,255,255);
        public static Color io = Color.Blue;
        public static int m = 20;
        public static float Z = 500 + Settings.bitmapSize / 2;
        private static Vector3 startLight = new Vector3(Settings.bitmapSize / 2, Settings.bitmapSize / 2, Settings.bitmapSize / 2);
        public static Vector3 GetLightVector(float span)
        {
            return new Vector3(startLight.X * ((float)Math.Sin(span) + 1), startLight.X * ((float)Math.Cos(span) + 1), Z);
        }
        public static Color GetColor(Vector3 source, Vector3 normal)
        {
            var R = normal * (float)ScalarProductNormalised(source, normal) * 2 - source;
            var V = new Vector3(0, 0, 1);
            double sp2 = ScalarProductNormalised(R, V);
            double sp1 = ScalarProductNormalised(source, normal);
            sp1 = sp1 > 0 ? sp1 : 0;
            sp2 = sp2 > 0 ? sp2 : 0;
            int colorR = (int)(kd * il.R * io.R * sp1 + ks * il.R * io.R * Math.Pow(sp2, m)) / 255;
            int colorG = (int)(kd * il.G * io.G * sp1 + ks * il.G * io.G * Math.Pow(sp2, m)) / 255;
            int colorB = (int)(kd * il.B * io.B * sp1 + ks * il.B * io.B * Math.Pow(sp2, m)) / 255;
            colorR = colorR > 255 ? 255 : colorR < 0 ? 0 : colorR;
            colorG = colorG > 255 ? 255 : colorG < 0 ? 0 : colorG;
            colorB = colorB > 255 ? 255 : colorB < 0 ? 0 : colorB;
            return sp1 > 0 ? Color.FromArgb(colorR, colorG, colorB) : Color.Black;
        }
        public static double ScalarProductNormalised(Vector3 v1, Vector3 v2)
        {
            double s1 = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            double s2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
            return (v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z) / (s1 * s2);
        }
    }
}
