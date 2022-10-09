using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDraw
{
    internal static class Tools
    {
        public static int GetDistanceSquared(Point p1, Point p2)
        {
            return (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
        }
        public static bool CollisionCheckPoints(Point p1, Point p2)
        {
            return GetDistanceSquared(p1, p2) < Vertex.radius * Vertex.radius;
        }
    }
}
