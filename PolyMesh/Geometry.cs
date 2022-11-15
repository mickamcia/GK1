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
        public static Color io = Color.Red;
        public static int m = 1;
        public static Color GetColor(Vector3 source, Vector3 reflection, Vector3 normal, Vector3 dest)
        {
            var diff = new Vector3(source.X - reflection.X, source.Y - reflection.Y, source.Z - reflection.Z);
            double sp1 = ScalarProduct(diff, normal);
            return sp1 > 0 ? Color.FromArgb((int)(kd * il.R * io.R * sp1 / 255), (int)(kd * il.G * io.G * sp1 / 255), (int)(kd * il.B * io.B * sp1 / 255)) : Color.Black;
        }
        public static double ScalarProduct(Vector3 v1, Vector3 v2)
        {
            double s1 = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            double s2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
            return (v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z) / (s1 * s2);
        }
    }
}
