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
        public static void Bresenham(Bitmap bitmap, Edge edge, Color color, int lineThickness)
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
                if (x >= 0 && y >= 0 && x < 800 && y < 800)
                {
                    bitmap.SetPixel(x, y, color);
                }
                for (int j = 1; j < lineThickness / 2; j++)
                {
                    if (x + j >= 0 && y >= 0 && x + j < 800 && y < 800)
                    {
                        bitmap.SetPixel(x + j, y, color);
                    }
                    if (x - j >= 0 && y >= 0 && x - j < 800 && y < 800)
                    {
                        bitmap.SetPixel(x - j, y, color);
                    }
                    if (x >= 0 && y + j>= 0 && x < 800 && y + j < 800)
                    {
                        bitmap.SetPixel(x, y + j, color);
                    }
                    if ( x>= 0 && y - j >= 0 && x < 800 && y + j < 800)
                    {
                        bitmap.SetPixel(x, y - j, color);
                    }
                }
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
        private static void plot(Bitmap bitmap, double x, double y, double c, Color foreColor)
        {
            int alpha = (int)(c * 255);
            if (alpha > 255) alpha = 255;
            if (alpha < 0) alpha = 0;
            Color color = Color.FromArgb(alpha, foreColor);
            if (x >= 0 && y >= 0 && x < 800 && y < 800)
            {
                bitmap.SetPixel((int)x, (int)y, color);
            }
        }

        private static int ipart(double x) { return (int)x; }

        private static int round(double x) { return ipart(x + 0.5); }

        private static double fpart(double x)
        {
            if (x < 0) return (1 - (x - Math.Floor(x)));
            return (x - Math.Floor(x));
        }

        private static double rfpart(double x)
        {
            return 1 - fpart(x);
        }
        //MODIFIED
        //https://rosettacode.org/wiki/Xiaolin_Wu%27s_line_algorithm#C#
        public static void Wu(Bitmap bitmap, Edge edge, Color color, int lineThickness)
        {
            double x0 = (double)edge.v1.location.X;
            double y0 = (double)edge.v1.location.Y;
            double x1 = (double)edge.v2.location.X;
            double y1 = (double)edge.v2.location.Y;
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            double temp;
            if (steep)
            {
                temp = x0; x0 = y0; y0 = temp;
                temp = x1; x1 = y1; y1 = temp;
            }
            if (x0 > x1)
            {
                temp = x0; x0 = x1; x1 = temp;
                temp = y0; y0 = y1; y1 = temp;
            }

            double dx = x1 - x0;
            double dy = y1 - y0;
            double gradient = dy / dx;

            double xEnd = round(x0);
            double yEnd = y0 + gradient * (xEnd - x0);
            double xGap = rfpart(x0 + 0.5);
            double xPixel1 = xEnd;
            double yPixel1 = ipart(yEnd);

            if (steep)
            {
                plot(bitmap, yPixel1 - lineThickness / 2, xPixel1, rfpart(yEnd) * xGap, color);
                plot(bitmap, yPixel1 + 1 + lineThickness / 2, xPixel1, fpart(yEnd) * xGap, color);
            }
            else
            {
                plot(bitmap, xPixel1, yPixel1 - lineThickness / 2, rfpart(yEnd) * xGap, color);
                plot(bitmap, xPixel1, yPixel1 + 1 + lineThickness / 2, fpart(yEnd) * xGap, color);
            }
            double intery = yEnd + gradient;

            xEnd = round(x1);
            yEnd = y1 + gradient * (xEnd - x1);
            xGap = fpart(x1 + 0.5);
            double xPixel2 = xEnd;
            double yPixel2 = ipart(yEnd);
            if (steep)
            {
                plot(bitmap, yPixel2 - lineThickness / 2, xPixel2, rfpart(yEnd) * xGap, color);
                plot(bitmap, yPixel2 + 1 + lineThickness / 2, xPixel2, fpart(yEnd) * xGap, color);
            }
            else
            {
                plot(bitmap, xPixel2, yPixel2 - lineThickness / 2, rfpart(yEnd) * xGap, color);
                plot(bitmap, xPixel2, yPixel2 + 1 + lineThickness / 2, fpart(yEnd) * xGap, color);
            }

            if (steep)
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    for (int i = 0; i < lineThickness / 2; i++)
                    {
                        bitmap.SetPixel((int)(intery - i), x, color);
                        bitmap.SetPixel((int)(intery + i + 1), x, color);
                    }
                    plot(bitmap, ipart(intery) - lineThickness / 2, x, rfpart(intery), color);
                    plot(bitmap, ipart(intery) + 1 + lineThickness / 2, x, fpart(intery), color);
                    intery += gradient;
                }
            }
            else
            {
                for (int x = (int)(xPixel1 + 1); x <= xPixel2 - 1; x++)
                {
                    for (int i = 0; i < lineThickness / 2; i++)
                    {
                        bitmap.SetPixel(x, (int)(intery - i), color);
                        bitmap.SetPixel(x, (int)(intery + i + 1), color);
                    }
                    plot(bitmap, x, ipart(intery) - lineThickness / 2, rfpart(intery), color);
                    plot(bitmap, x, ipart(intery) + 1 + lineThickness / 2, fpart(intery), color);
                    intery += gradient;
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
