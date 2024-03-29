﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PolyMask
{
    public class Polygon
    {
        public List<PointF> points;
        public Polygon()
        {
            points = new();
        }
        public bool Contains(float X, float Y)
        {
            bool result = false;
            int j = points.Count - 1;
            for(int i = 0; i < points.Count; i++)
            {
                if (points[i].Y < Y && points[j].Y >= Y || points[j].Y < Y && points[i].Y >= Y)
                {
                    if (points[i].X + (Y - points[i].Y) / (points[j].Y - points[i].Y) * (points[j].X - points[i].X) < X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
    public enum CellType
    {
        Applied,
        Calculated,
        Unknown,
        Other,
    }
    public enum BrushType
    {
        Filler,
        Eraser,
    }
    public enum FillType
    {
        Whole,
        Polygon,
        Brush,
    }
    public static class Settings
    {
        public static int Brightness = 255;
        public const int PictureWidth = 800;
        public const int PictureHeigth = 800;
        public const int HistogramWidth = 288;
        public const int HistogramHeight = 172;
        public const int HistogramMargin = 16;
        public static float[] Kernel = Kernels.Identity;
        public static BrushType BrushType = BrushType.Filler;
        public static FillType FillType = FillType.Brush;
        public static int BrushSize = 10;
    }
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color color)
        {
            int index = x + (y * Width);
            Bits[index] = color.ToArgb();
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
