using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace PolyMesh
{
    public class Triangle
    {
        public Vector3[] vertices;
        public Vector3[] normals;
        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 vn1, Vector3 vn2, Vector3 vn3)
        {
            vertices = new Vector3[3];
            vertices[0] = v1;
            vertices[1] = v2;
            vertices[2] = v3;
            normals = new Vector3[3];
            normals[0] = vn1;
            normals[1] = vn2;
            normals[2] = vn3;
        }
        public void Paint(Bitmap bits, Color color)
        {
            var sorted = (Vector3[])vertices.Clone();
            Array.Sort(sorted, (v1, v2) => v1.Y > v2.Y ? 1 : 0);
            double ymin = sorted[0].Y;
            double ymax = sorted[^1].Y;
            for (int i = (int)ymin; i <= (int)ymax; i++)
            {

            }
        }
        public void PaintOld(Bitmap bits, Color color)
        {
            double ymax = vertices.Max(p => p.Y);
            double ymin = vertices.Min(p => p.Y);
            List<(Vector3 v1, Vector3 v2)> scan = new();
            for (int i = (int)ymin; i <= (int)ymax; i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    if ((int)vertices[j].Y == i)
                    {
                        var v0 = vertices[j];
                        var v1 = vertices[(j + 1) % vertices.Length];
                        var v2 = vertices[(j + vertices.Length - 1) % vertices.Length];
                        if (v1.Y > v0.Y)
                        {
                            scan.Add((v0, v1));
                        }
                        else
                        {
                            scan.Remove((v0, v1));
                            scan.Remove((v1, v0));
                        }
                        if (v2.Y > v0.Y)
                        {
                            scan.Add((v0, v2));
                        }
                        else
                        {
                            scan.Remove((v0, v2));
                            scan.Remove((v2, v0));
                        }
                    }
                }
                var scan2 = scan.Select(x => (x.v2.Y != x.v1.Y) ? (int)((i - x.v1.Y) * (x.v2.X - x.v1.X) / (x.v2.Y - x.v1.Y) + x.v1.X) : Math.Max((int)x.v1.X, (int)x.v2.X)).ToArray();
                Array.Sort(scan2);
                if (scan2 == null || scan2.Length == 0) continue;
                for(int j = scan2[0]; j < scan2[^1]; j++)
                {
                    if (j >= 800 || i >= 800 || j < 0 || i < 0) break;
                    bits.SetPixel(j, i, color);
                }
            }
        }
    }
    public class Model
    {
        public List<Vector3> vertices;
        public List<Vector3> normals;
        public List<Triangle> triangles;
        public Model()
        {
            vertices = new List<Vector3>();
            normals = new List<Vector3> ();
            triangles = new List<Triangle>();
        }
    }
}
