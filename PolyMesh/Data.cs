using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace PolyMesh
{
    public class Vertex
    {
        public double x;
        public double y;
        public double z;
        public Vertex(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    public class Triangle
    {
        public Vertex[] vertices;
        public Vertex[] normals;
        public Triangle(Vertex v1, Vertex v2, Vertex v3, Vertex vn1, Vertex vn2, Vertex vn3)
        {
            vertices = new Vertex[3];
            vertices[0] = v1;
            vertices[1] = v2;
            vertices[2] = v3;
            normals = new Vertex[3];
            normals[0] = vn1;
            normals[1] = vn2;
            normals[2] = vn3;
        }
        public void Paint(Bitmap bits, Color color)
        {
            var sorted = (Vertex[])vertices.Clone();
            Array.Sort(sorted, (v1, v2) => v1.y > v2.y ? 1 : 0);
            double ymin = sorted[0].y;
            double ymax = sorted[^1].y;
            for (int i = (int)ymin; i <= (int)ymax; i++)
            {

            }
        }
        public void PaintOld(Bitmap bits, Color color)
        {
            double ymax = vertices.Max(p => p.y);
            double ymin = vertices.Min(p => p.y);
            List<(Vertex v1, Vertex v2)> scan = new();
            for (int i = (int)ymin; i <= (int)ymax; i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    if ((int)vertices[j].y == i)
                    {
                        var v0 = vertices[j];
                        var v1 = vertices[(j + 1) % vertices.Length];
                        var v2 = vertices[(j + vertices.Length - 1) % vertices.Length];
                        if (v1.y > v0.y)
                        {
                            scan.Add((v0, v1));
                        }
                        else
                        {
                            scan.Remove((v0, v1));
                            scan.Remove((v1, v0));
                        }
                        if (v2.y > v0.y)
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
                var scan2 = scan.Select(x => (x.v2.y != x.v1.y) ? (int)((i - x.v1.y) * (x.v2.x - x.v1.x) / (x.v2.y - x.v1.y) + x.v1.x) : Math.Max((int)x.v1.x, (int)x.v2.x)).ToArray();
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
        public List<Vertex> vertices;
        public List<Vertex> normals;
        public List<Triangle> triangles;
        public Model()
        {
            vertices = new List<Vertex>();
            normals = new List<Vertex> ();
            triangles = new List<Triangle>();
        }
    }
}
