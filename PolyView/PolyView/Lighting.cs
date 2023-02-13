using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Color color;
        public enum LightType
        {
            SpotLight = 0,
            PointLight = 1,
            DayLight = 2,
        }
        public LightType type;
        public Vector3 direction;

        public LightSource()
        {
            color = Color.White;
            modelMatrixScale = Matrix4x4.Identity;
            modelMatrixTranslation = Matrix4x4.Identity;
            modelMatrixRotation = Matrix4x4.Identity;
            modelMatrix = Matrix4x4.Identity;
            model_pos = new Vector4(0, 0, 0, 1);
            scene_pos = new Vector4(0, 0, 0, 1);
            view_pos = new Vector4(0, 0, 0, 1);
            type = LightType.PointLight;
            direction = new Vector3(0, 0, 1);
        }
    }
    public static class Lighting
    {
        public static float kd = 0.4f;
        public static float ks = 0.4f;
        public static float ka = 0.2f;
        public static Color il = Color.FromArgb(255, 255, 255);
        //public static Color org = Color.Blue;
        public static int m = 80;

        public static Color GetColor(Vector3 position, Vector3 normal, Color org)
        {
            float colorR = ka;
            float colorG = ka;
            float colorB = ka;

            normal = Vector3.Normalize(normal);
            var V = CameraGeometry.GetCameraPosition(MainWindowForm.scene) - position;
            var distance = V.Length();
            V = Vector3.Normalize(V);
            //point
            foreach (LightSource light in MainWindowForm.scene.lights)
            {
                Vector3 ls = new Vector3(light.scene_pos.X, light.scene_pos.Y, light.scene_pos.Z);
                if ((light.type == LightSource.LightType.DayLight && Settings.LightingDaylight) || (light.type == LightSource.LightType.PointLight && Settings.LightOnStationaryObject))
                {
                    float sp1 = Vector3.Dot(normal, Vector3.Normalize(ls - position));
                    sp1 = sp1 > 0 ? sp1 : 0;

                    var R = normal * sp1 * 2 - Vector3.Normalize(ls - position);
                    float sp2 = Vector3.Dot(Vector3.Normalize(R), V);

                    sp2 = sp2 > 0 ? sp2 : 0;
                    sp2 = (float)Math.Pow(sp2, m);

                    colorR += (kd * il.R * sp1 + ks * il.R * sp2) / 255;
                    colorG += (kd * il.G * sp1 + ks * il.G * sp2) / 255;
                    colorB += (kd * il.B * sp1 + ks * il.B * sp2) / 255;
                }
                //spotlight
                if (light.type == LightSource.LightType.SpotLight && Settings.LightOnMovingObject)
                {
                    float sp1 = Vector3.Dot(normal, Vector3.Normalize(ls - position));
                    sp1 = sp1 > 0 ? sp1 : 0;

                    var R = normal * sp1 * 2 - Vector3.Normalize(ls - position);
                    
                    float sp2 = Vector3.Dot(Vector3.Normalize(R), V);

                    sp2 = sp2 > 0 ? sp2 : 0;
                    sp2 = (float)Math.Pow(sp2, m);


                    int p = 10; 
                    float spotlight = Vector3.Dot(-1 * Vector3.Normalize(light.direction), Vector3.Normalize(ls - position));
                    spotlight = spotlight > 0 ? spotlight : 0;
                    spotlight = (float)Math.Pow(spotlight, p);

                    colorR += (kd * il.R * sp1 + ks * il.R * sp2) * (spotlight / 255);
                    colorG += (kd * il.G * sp1 + ks * il.G * sp2) * (spotlight / 255);
                    colorB += (kd * il.B * sp1 + ks * il.B * sp2) * (spotlight / 255);
                }
            }


            colorR *= org.R;
            colorG *= org.G;
            colorB *= org.B;

            colorR = colorR > 255 ? 255 : colorR < 0 ? 0 : colorR;
            colorG = colorG > 255 ? 255 : colorG < 0 ? 0 : colorG;
            colorB = colorB > 255 ? 255 : colorB < 0 ? 0 : colorB;
            Color color = Color.FromArgb((int)colorR, (int)colorG, (int)colorB);
            if (Settings.LightingFog) return Fog(color, distance);
            return color;
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
        public static Color interpolateColors(Color[] colors, (float w1, float w2, float w3) bar)
        {
            var R = (int)(colors[0].R * bar.w1 + colors[1].R * bar.w2 + colors[2].R * bar.w3);
            var G = (int)(colors[0].G * bar.w1 + colors[1].G * bar.w2 + colors[2].G * bar.w3);
            var B = (int)(colors[0].B * bar.w1 + colors[1].B * bar.w2 + colors[2].B * bar.w3);
            R = R > 255 ? 255 : R;
            G = G > 255 ? 255 : G;
            B = B > 255 ? 255 : B;
            R = R < 0 ? 0 : R;
            G = G < 0 ? 0 : G;
            B = B < 0 ? 0 : B;
            return Color.FromArgb(R, G, B);
        }
        public static Color Fog(Color color, float distance)
        {
            int start = 500;
            int end = 2000;
            if (distance > start)
            {
                if (distance < end)
                {
                    float fog = (float)(distance - start) / (float)(end - start);
                    float R = fog * (255 - color.R);
                    float G = fog * (255 - color.G);
                    float B = fog * (255 - color.B);
                    return Color.FromArgb(color.R + (int)R, color.G + (int)G, color.B + (int)B);
                }
                else return Color.White;
            }
            return color;
        }
    }
}
