using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

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
        /*
        private void FillWithAETAndAdvance(Graphics G, List<SimpleAETPointer> AET, int y)
        {
            AET.Sort(delegate (SimpleAETPointer a, SimpleAETPointer b)
            {
                if (a.X == b.X) return 0;
                if (a.X > b.X) return 1;
                return -1;
            });
            for (int i = 0; i < AET.Count - 1; i += 2)
            {
                // putpixel od i do i+1
                RenderScannedLine(G, AET[i].X, AET[i + 1].X, y);
            }
            foreach (var pointer in AET)
                pointer.Advance();
        }
        public void FillScanLine(Graphics G)
        {
            // niech każda edge zainicjuje sobie AET
            ResetEdgesBeforeDrawing();
            List<SimpleAETPointer> AET = new List<SimpleAETPointer>();
            // min i max dla punktów tego triangle
            for (int scanline = yMin; scanline <= yMax; scanline++)
            {
                // znajdz punkty które przecinam
                List<Point3D> intersectedPoints = GetIntersected(scanline);
                if (intersectedPoints.Count > 0)
                {
                    foreach (var point in intersectedPoints)
                    {
                        // index +1 lub -1 (z modulo), zakłada że posortowałeś punkty (mi to robi coś innego)
                        Point3D prevPoint = GetPrev(point);
                        Point3D nextPoint = GetNext(point);
                        Edge3D? prevEdge = GetEdge(prevPoint, point);
                        Edge3D? nextEdge = GetEdge(nextPoint, point);
                        // this shouldn't happen (dla kompilatora)
                        if (prevEdge == null || nextEdge == null)
                        {
                            // do debugu - olej
                            foreach (var edge in edges)
                                using (Pen pen = new Pen(Color.Red, 5))
                                    G.DrawLine(pen, edge.PointA.Point2D, edge.PointB.Point2D);
                            return;
                        }
                        // z prezki
                        if (prevPoint.Y >= point.Y)
                            AET.Add(prevEdge.AETPointer);
                        else
                            AET.Remove(prevEdge.AETPointer);

                        if (nextPoint.Y >= point.Y)
                            AET.Add(nextEdge.AETPointer);
                        else
                            AET.Remove(nextEdge.AETPointer);
                    }
                }
                if (AET.Count > 0)
                    FillWithAETAndAdvance(G, AET, scanline);
                //else
                //  FillBetweenPoints(G, intersectedPoints, scanline);
            }
        }
        */
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
