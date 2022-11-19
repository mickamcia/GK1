using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        public Vector3 v1;
        public Vector3 v2;
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
    }
    public class Triangle
    {
        public Vector3[] vertices;
        public Vector3[] normals;
        public AETP[] pointers;
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
            pointers = new AETP[3];
            for(int i = 0; i < 3; i++)
            {
                pointers[i] = new AETP();
                pointers[i].startx = vertices[i].X;
                pointers[i].currx = vertices[i].X;
                pointers[i].x = (int)vertices[i].X;
                pointers[i].ymax = Math.Max(vertices[i].Y, vertices[(i + 1) % vertices.Length].Y);
                pointers[i].one_m = (vertices[i].X - vertices[(i + 1) % vertices.Length].X) / (vertices[i].Y - vertices[(i + 1) % vertices.Length].Y);
                pointers[i].v1 = vertices[i];
                pointers[i].v2 = vertices[(i + 1) % vertices.Length];
            }
        }
        public void ResetEdges()
        {
            foreach(var p in pointers)
            {
                p.reset();
            }
        }
        public void Paint(Bitmap bits, Color color)
        {
            ResetEdges();
            color = Color.FromArgb(Settings.rnd.Next(256), Settings.rnd.Next(256), Settings.rnd.Next(256));
            var verts = vertices.OrderBy(p => p.Y).ToArray();
            double ymax = verts[verts.Length - 1].Y;
            double ymin = verts[0].Y;
            List<AETP> AET = new List<AETP>();
            for (int y = (int)ymin; y < ymax; y++)
            {
                foreach(var v in verts.Where(p => p.Y == y))
                {
                    if (pointers[i].v1.Y > v.Y)
                    {
                        //dodac
                        AET.Add(pointers[i]);
                    }
                    else
                    {
                        //usunac
                        AET.Remove(pointers[i]);
                    }
                    if (pointers[i].v2.Y > v.Y)
                    {
                        //dodac
                        AET.Add(pointers[(i + 1) % pointers.Length]);
                    }
                    else
                    {
                        //usunac
                        AET.Remove(pointers[(i + 1) % pointers.Length]);
                    }
                }
                if (AET.Count > 0)
                {
                    FillAET(bits, AET, y, color);
                }
            }
        }
        private void FillAET(Bitmap bits, List<AETP> AET, int y, Color color) //PRZEROBIC
        {
            AET.Sort(delegate (AETP p1, AETP p2)
            {
                if (p1.x <= p2.x) return 0;
                else
                    return 1;
            });
            for (int i = 0; i < AET.Count - 1; i += 2)
            {
                FillLine(bits, AET[i].x, AET[i + 1].x, y, color);
            }
            foreach (var ptr in AET)
                ptr.advance();
        }
        private void FillLine(Bitmap bits, int x1, int x2, int y, Color color)
        {
            for (int x = x1; x < x2; x++)
            {
                if (x >= bits.Width || y >= bits.Height || x < 0 || y < 0) break;
                bits.SetPixel(x, y, color);
            }
        }
        public void PaintOld(Bitmap bits, Color color)
        {
            int ymax = (int)vertices.Max(p => p.Y);
            int ymin = (int)vertices.Min(p => p.Y);
            List<(Vector3 v1, Vector3 v2)> scan = new();
            for (int i = ymin; i <= ymax; i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    if ((int)vertices[j].Y == i)
                    {
                        var v0 = vertices[j];
                        var v1 = vertices[(j + 1) % vertices.Length];
                        var v2 = vertices[(j + vertices.Length - 1) % vertices.Length];
                        if ((int)v1.Y > (int)v0.Y)
                        {
                            scan.Add((v0, v1));
                        }
                        else
                        {
                            scan.Remove((v0, v1));
                            scan.Remove((v1, v0));
                        }
                        if ((int)v2.Y > (int)v0.Y)
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
                var scan2 = scan.Select(x => (int)((i - x.v1.Y) * (x.v2.X - x.v1.X) / (x.v2.Y - x.v1.Y) + x.v1.X)).ToArray();
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
