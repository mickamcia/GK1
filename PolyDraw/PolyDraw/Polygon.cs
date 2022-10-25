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
                vertices.Add(new Vertex(random, this));
            }
            for (int i = 0; i < count; i++)
            {
                edges.Add(new Edge(vertices[i], vertices[(i + 1) % count], this));
            }
        }
        public Polygon(PointF mid, float radius, int count)
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            for (int i = 0; i < count; i++)
            {
                vertices.Add(new Vertex(new PointF((float)(mid.X + radius * Math.Cos(i * 2 * Math.PI / count)), (float)(mid.Y + radius * Math.Sin(i * 2 * Math.PI / count))), this));
            }
            for (int i = 0; i < count; i++)
            {
                edges.Add(new Edge(vertices[i], vertices[(i + 1) % count], this));
            }
        }
        public void AddVertex(Vertex v)
        {
            if (vertices.Count == 0)
            {
                vertices.Add(v);
                edges.Add(new Edge(v, v, this));
            }
            else
            {
                vertices.Add(v);
                edges[^1].v2 = v;
                edges.Add(new Edge(v, vertices[0], this));
            }
        }
        public void RemoveVertex(Vertex v)
        {
            if (!vertices.Contains(v))
            {
                return;
            }
            int index = vertices.IndexOf(v);
            edges[(index + edges.Count - 1) % edges.Count].v2 = vertices[(index + 1) % vertices.Count];
            vertices.RemoveAt(index);
            edges.RemoveAt(index);
        }
        public void RemoveEdge(Edge e)
        {
            if (!edges.Contains(e))
            {
                return;
            }
            RemoveVertex(e.v1);
            RemoveVertex(e.v2);
        }
        public void Draw(Bitmap bitmap, Color color, LineType lineType, int lineThickness)
        {
            foreach(var e in edges)
            {
                e.Draw(bitmap, color, lineType, lineThickness);
            }
            foreach (var v in vertices)
            {
                v.Draw(bitmap, color);
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
        public Relation? relation;
        public Polygon parent;
        public Vertex v1;
        public Vertex v2;
        public Edge(Vertex v1, Vertex v2, Polygon parent)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.parent = parent;
        }
        public void Draw(Bitmap bitmap, Color color, LineType lineType, int lineThickness)
        {
            if (lineType == LineType.Bresenham)
            {
                Tools.Bresenham(bitmap, this, color, lineThickness);
            }
            else if(lineType == LineType.Wu)
            {
                Tools.Wu(bitmap, this, color, lineThickness);
            }
            else
            {
                using var g = Graphics.FromImage(bitmap);
                g.DrawLine(new Pen(new SolidBrush(color), lineThickness), v1.location, v2.location);
            }
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
        public Polygon parent;

        public Vertex(PointF p, Polygon parent)
        {
            location = p;
            this.parent = parent;
        }
        public Vertex(Random random, Polygon parent)
        {
            location = new PointF(random.Next(800), random.Next(800));
            this.parent = parent;
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
