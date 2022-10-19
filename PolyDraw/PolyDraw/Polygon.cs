using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDraw
{
    public class Polygon
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        public Polygon()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }
        public Polygon(Random random, int count)
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            for (int i = 0; i < count; i++)
            {
                vertices.Add(new Vertex(random));
            }
            for (int i = 0; i < count; i++)
            {
                edges.Add(new Edge(vertices[i], vertices[(i + 1) % count]));
            }
        }
        public void AddVertex(Vertex v)
        {
            if (vertices.Count == 0)
            {
                vertices.Add(v);
                edges.Add(new Edge(v, v));
            }
            else
            {
                vertices.Add(v);
                edges[^1].v2 = v;
                edges.Add(new Edge(v, vertices[0]));
            }
        }
        public void Draw(Bitmap bitmap, Color color)
        {
            foreach(var v in vertices)
            {
                v.Draw(bitmap, color);
            }
            foreach(var e in edges)
            {
                e.Draw(bitmap, color);
            }
            using var g = Graphics.FromImage(bitmap);
            g.FillPolygon(new SolidBrush(Color.FromArgb(100, color)), vertices.Select(v => v.location).ToArray());
        }
        public bool CheckCollision(PointF point)
        {
            return Tools.IsPointInPolygon(this, point);
        }
    }
    public class Edge
    {
        public Vertex v1;
        public Vertex v2;
        public Edge(Vertex v1, Vertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        public void Draw(Bitmap bitmap, Color color)
        {
            using var g = Graphics.FromImage(bitmap);
            g.DrawLine(new Pen(color), v1.location, v2.location);
            //Tools.Bresenham(bitmap, this, Color.Black);
        }
        public bool CheckCollision(PointF point)
        {
            return Tools.PointDistance(v1.location, v2.location) + 1.0 > Tools.PointDistance(v1.location, point) + Tools.PointDistance(v2.location, point); 
        }
    }
    public class Vertex
    {
        public PointF location;
        public const int radius = 5;

        public Vertex(PointF p)
        {
            location = p;
        }
        public Vertex(Random random)
        {
            location = new PointF(random.Next(800), random.Next(800));
        }
        public void Draw(Bitmap bitmap, Color color)
        {
            using Graphics g = Graphics.FromImage(bitmap);
            g.FillEllipse(new SolidBrush(color), location.X - radius, location.Y - radius, 2 * radius, 2 * radius);
        }
        public bool CheckCollision(PointF point)
        {
            return Tools.PointDistance(location, point) < Tools.error;
        }
    }
}
