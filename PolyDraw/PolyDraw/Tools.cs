using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDraw
{
    public static class Tools
    {
        public const double error = 8.0;
        //https://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm
        public static void Bresenham(Bitmap bitmap, Edge edge, Color color)
        {
            int x = (int)edge.v1.location.X;
            int y = (int)edge.v1.location.Y;
            int w = (int)edge.v2.location.X - x;
            int h = (int)edge.v2.location.Y - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                bitmap.SetPixel(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
        //https://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
        public static bool IsPointInPolygon(Polygon p, PointF testPoint)
        {
            var points = p.vertices.Select(v => v.location).ToArray(); 
            bool result = false;
            int j = points.Length - 1;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].Y < testPoint.Y && points[j].Y >= testPoint.Y || points[j].Y < testPoint.Y && points[i].Y >= testPoint.Y)
                {
                    if (points[i].X + (testPoint.Y - points[i].Y) / (points[j].Y - points[i].Y) * (points[j].X - points[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        public static double PointDistance(PointF p1, PointF p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
        public static PointF EdgeMidPoint(Edge e)
        {
            return new PointF((e.v1.location.X + e.v2.location.X) / 2, (e.v1.location.Y + e.v2.location.Y) / 2);
        }
    }
}
