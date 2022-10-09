using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDraw
{
    internal class Polygon
    {
        public readonly List<Vertex> vertices;
        public bool selected;
        public bool finished;
        public Polygon()
        {
            vertices = new List<Vertex>();
            selected = true;
            finished = false;
        }
        public Polygon(Vertex ver)
        {
            vertices = new List<Vertex>();
            vertices.Add(ver);
            selected = true;
            finished = false;
        }
        public void AddVertexAt(Point point)
        {
            if (Tools.CollisionCheckPoints(point, vertices.ElementAt(0).point))
            {
                finished = true;
                selected = false;
            }
            if (!CollisionCheckInPolygon(point))
            {
                vertices.Add(new Vertex(point));
            }
        }
        public void Draw(Graphics g)
        {
            var points = vertices.ToArray();
            for(int i = 0; i < points.Length; i++)
            {
                g.FillEllipse(points[i].selected ? Brushes.Blue : this.selected ? Brushes.DarkBlue : Brushes.Black, points[i].point.X - Vertex.radius / 2, points[i].point.Y - Vertex.radius / 2, Vertex.radius, Vertex.radius);
            }
            for (int i = 0; i < points.Length - 1; i++)
            {
                g.DrawLine(Pens.Black, points[i].point, points[i + 1].point);
            }
            if (finished)
            {
                g.DrawLine(Pens.Black, points[0].point, points[^1].point);
            }
        }
        public bool CollisionCheckInPolygon(Point point)
        {
            foreach (Vertex vert in vertices)
            {
                if (Tools.CollisionCheckPoints(point, vert.point))
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class Vertex
    {
        public const int radius = 16;
        public Point point;
        public bool selected;
        public Vertex(Point point)
        {
            this.point = point;
            selected = false;
        }
    }
}
