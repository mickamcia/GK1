﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PolyView
{
    public class LightSource
    {
        public Vector4 model_pos;
        public Vector4 scene_pos;
        public Vector4 view_pos;

        public Matrix4x4 modelMatrixScale;
        public Matrix4x4 modelMatrixTranslation;
        public Matrix4x4 modelMatrixRotation;
        public Matrix4x4 modelMatrix;

        public LightSource()
        {
            modelMatrixScale = Matrix4x4.Identity;
            modelMatrixTranslation = Matrix4x4.Identity;
            modelMatrixRotation = Matrix4x4.Identity;
            modelMatrix = Matrix4x4.Identity;
            model_pos = new Vector4(0, 0, 0, 1);
            scene_pos = new Vector4(0, 0, 0, 1);
            view_pos = new Vector4(0, 0, 0, 1);
        }
    }
    public static class Lighting
    {
        public static float kd = 1;
        public static float ks = 1;
        public static float ka = 1;
        public static Color il = Color.FromArgb(255, 255, 255);
        public static Color io = Color.Blue;
        public static int m = 20;
        
        public static Color GetColor(Vector3 source, Vector3 normal)
        {
            var R = normal * Vector3.Dot(normal, source) * 2 - source;
            var V = new Vector3(0, 0, 1);
            float sp2 = Vector3.Dot(Vector3.Normalize(R), V);
            float sp1 = Vector3.Dot(Vector3.Normalize(normal), Vector3.Normalize(source));
            sp1 = sp1 > 0 ? sp1 : 0;
            sp2 = sp2 > 0 ? sp2 : 0;
            sp1 *= kd / 255;
            sp2 = (float)Math.Pow(sp2, m) * ks / 255;
            int colorR = (int)(ka + il.R * io.R * sp1 + il.R * io.R * sp2);
            int colorG = (int)(ka + il.G * io.G * sp1 + il.G * io.G * sp2);
            int colorB = (int)(ka + il.B * io.B * sp1 + il.B * io.B * sp2);
            colorR = colorR > 255 ? 255 : colorR < 0 ? 0 : colorR;
            colorG = colorG > 255 ? 255 : colorG < 0 ? 0 : colorG;
            colorB = colorB > 255 ? 255 : colorB < 0 ? 0 : colorB;
            return Color.FromArgb(colorR, colorG, colorB);
        }
        public static (float w1, float w2, float w3) GetBarycentricWeights(Vector4[] positions, float x, float y)
        {
            float div = (positions[1].Y - positions[2].Y) * (positions[0].X - positions[2].X) + (positions[2].X - positions[1].X) * (positions[0].Y - positions[2].Y);
            float w1 = (positions[1].Y - positions[2].Y) * (x - positions[2].X) + (positions[2].X - positions[1].X) * (y - positions[2].Y);
            float w2 = (positions[2].Y - positions[0].Y) * (x - positions[2].X) + (positions[0].X - positions[2].X) * (y - positions[2].Y);
            w1 /= div;
            w2 /= div;
            float w3 = 1 - w1 - w2;
            return (w1, w2, w3);
        }
    }
}
