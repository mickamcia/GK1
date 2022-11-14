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
        public static Color GetColor(Vertex source, Vertex reflection, Vertex normal, Vertex dest)
        {
            var diff = new Vertex(source.x - reflection.x, source.y - reflection.y, source.z - reflection.z);
            double sp1 = ScalarProduct(diff, normal);
            return sp1 > 0 ? Color.FromArgb((int)(kd * il.R * io.R * sp1 / 255), (int)(kd * il.G * io.G * sp1 / 255), (int)(kd * il.B * io.B * sp1 / 255)) : Color.Black;
        }
        public static double ScalarProduct(Vertex v1, Vertex v2)
        {
            double s1 = Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z);
            double s2 = Math.Sqrt(v2.x * v2.x + v2.y * v2.y + v2.z * v2.z);
            return (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z) / (s1 * s2);
        }
    }
}
