using System.Diagnostics;
using System.Numerics;

namespace PolyMesh
{
    public static class Settings
    {
        public const string path = "C:\\Users\\s\\Source\\Repos\\mickamcia\\GK1\\PolyMesh\\sphereXXL.obj";
        //const string path = "C:\\Users\\user\\source\\repos\\mickamcia\\GK1\\PolyMesh\\sphereXXL.obj";
        public const int bitmapSize = 800;
        public const int modelScale = 300;
        public static Random rnd = new();
        public static Stopwatch stopwatch = new();
    }
    public class Model
    {
        public List<Vector3> vertices;
        public List<Vector3> normals;
        public List<Triangle> triangles;
        public Model()
        {
            vertices = new List<Vector3>();
            normals = new List<Vector3>();
            triangles = new List<Triangle>();
        }
    }
    public class AETP
    {
        public double startx;
        public double ymax;
        public double currx;
        public int x;
        public double one_m;
        public AETP(double ymax, double x, double one_m)
        {
            this.ymax = ymax;
            this.startx = x;
            this.currx = x;
            this.x = (int)startx;
            this.one_m = one_m;
        }
        public AETP()
        {

        }
        public void advance()
        {
            currx += one_m;
            x = (int)currx;
        }
        public void reset()
        {
            currx = startx;
            x = (int)currx;
        }
    }
    public class Vertex
    {
        public Vector3 position;
        public Vector3 normal;
        public Vertex next;
        public Vertex prev;
        public AETP pointer;
        public Vertex(Vector3 position, Vector3 normal)
        {
            this.position = position;
            this.normal = normal;
            next = prev = this;
            pointer = new AETP();
        }
    }
    public class Triangle
    {
        public List<Vertex> vertices;
        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 vn1, Vector3 vn2, Vector3 vn3)
        {
            vertices = new();
            vertices.Add(new Vertex(v1, vn1));
            vertices.Add(new Vertex(v2, vn2));
            vertices.Add(new Vertex(v3, vn3));
            for(int i = 0; i < vertices.Count; i++)
            {
                vertices[i].next = vertices[(i + 1) % vertices.Count];
                vertices[i].prev = vertices[(i + vertices.Count - 1) % vertices.Count];
            }
            GenerateAETP();
        }
        public Vector3 GetBarycentricNormalVector(float x, float y)
        {
            float div = (vertices[1].position.Y - vertices[2].position.Y) * (vertices[0].position.X - vertices[2].position.X) + (vertices[2].position.X - vertices[1].position.X) * (vertices[0].position.Y - vertices[2].position.Y);
            float w1 = (vertices[1].position.Y - vertices[2].position.Y) * (x - vertices[2].position.X) + (vertices[2].position.X - vertices[1].position.X) * (y - vertices[2].position.Y);
            float w2 = (vertices[2].position.Y - vertices[0].position.Y) * (x - vertices[2].position.X) + (vertices[0].position.X - vertices[2].position.X) * (y - vertices[2].position.Y);
            w1 /= div;
            w2 /= div;
            float w3 = 1 - w1 - w2;
            return vertices[0].normal * w1 + vertices[1].normal * w2 + vertices[2].normal * w3;
        }
        public void GenerateAETP()
        {
            for(int i = 0; i < vertices.Count; i++)
            {
                var temp = new AETP();
                temp.startx = vertices[i].position.Y > vertices[i].next.position.Y ? vertices[i].next.position.X : vertices[i].position.X;
                temp.currx = temp.startx;
                temp.x = (int)temp.startx;
                temp.ymax = Math.Max(vertices[i].position.Y, vertices[i].next.position.Y);
                temp.one_m = (vertices[i].position.X - vertices[i].next.position.X) / (vertices[i].position.Y - vertices[i].next.position.Y);
                vertices[i].pointer = temp;
            }
        }
        public void ResetEdges()
        {
            foreach(var v in vertices)
            {
                v.pointer.reset();
            }
        }
        public void Paint(Bitmap bits)
        {
            ResetEdges();
            double ymax = vertices.Max(p => p.position.Y);
            double ymin = vertices.Min(p => p.position.Y);
            List<AETP> AET = new List<AETP>();
            for (int y = (int)ymin; y <= ymax; y++)
            {
                foreach(var v in vertices.Where(p => (int)p.position.Y == y))
                {
                    if ((int)v.next.position.Y > (int)v.position.Y)
                    {
                        AET.Add(v.pointer);
                    }
                    else
                    {
                        AET.Remove(v.pointer);
                    }
                    if ((int)v.prev.position.Y > (int)v.position.Y)
                    {
                        AET.Add(v.prev.pointer);
                    }
                    else
                    {
                        AET.Remove(v.prev.pointer);
                    }
                }
                if (AET.Count > 0)
                {
                    FillAET(bits, AET, y);
                }
            }
        }
        private void FillAET(Bitmap bits, List<AETP> AET, int y)
        {
            AET.Sort(delegate (AETP p1, AETP p2)
            {
                if (p1.x <= p2.x) return 0;
                else
                    return 1;
            });
            for (int i = 0; i < AET.Count - 1; i += 2)
            {
                FillLine(bits, AET[i].x, AET[i + 1].x, y);
            }
            foreach (var ptr in AET)
            {
                ptr.advance();
            }
        }
        private void FillLine(Bitmap bits, int x1, int x2, int y)
        {
            for (int x = x1; x < x2; x++)
            {
                if (x >= bits.Width || y >= bits.Height || x < 0 || y < 0) break;

                var ls = Geometry.GetLightVector((float)Settings.stopwatch.ElapsedMilliseconds / 1000);

                var bar = GetBarycentricNormalVector(x, y);
                bits.SetPixel(x, y, Geometry.GetColor(ls, bar));
            }
        }
        public void PaintOld(Bitmap bits, Color color)
        {
            int ymax = (int)vertices.Max(p => p.position.Y);
            int ymin = (int)vertices.Min(p => p.position.Y);
            List<(Vertex v1, Vertex v2)> scan = new();
            for (int i = ymin; i <= ymax; i++)
            {
                for (int j = 0; j < vertices.Count; j++)
                {
                    if ((int)vertices[j].position.Y == i)
                    {
                        var v0 = vertices[j];
                        var v1 = vertices[(j + 1) % vertices.Count];
                        var v2 = vertices[(j + vertices.Count - 1) % vertices.Count];
                        if ((int)v1.position.Y > (int)v0.position.Y)
                        {
                            scan.Add((v0, v1));
                        }
                        else
                        {
                            scan.Remove((v0, v1));
                            scan.Remove((v1, v0));
                        }
                        if ((int)v2.position.Y > (int)v0.position.Y)
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
                //var scan2 = scan.Select(x => Math.Abs(x.v2.Y - x.v1.Y) > 0.01 ? (int)((i - x.v1.Y) * (x.v2.X - x.v1.X) / (x.v2.Y - x.v1.Y) + x.v1.X) : Math.Min((int)x.v1.X, (int)x.v2.X)).ToArray();
                var scan2 = scan.Select(x => (int)((i - x.v1.position.Y) * (x.v2.position.X - x.v1.position.X) / (x.v2.position.Y - x.v1.position.Y) + x.v1.position.X)).ToArray();
                Array.Sort(scan2);
                if (scan2 == null || scan2.Length == 0) continue;
                for (int j = scan2[0]; j < scan2[^1]; j++)
                {
                    if (j >= 800 || i >= 800 || j < 0 || i < 0) break;
                    bits.SetPixel(j, i, color);
                }
            }
        }
    }
}
