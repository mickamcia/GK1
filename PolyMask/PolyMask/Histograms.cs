using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PolyMask
{
    public class Histogram
    {
        private Color c;
        private readonly Func<Color,int> f;
        public DirectBitmap Bits;
        private readonly int[] Vals;
        public Histogram(Func<Color, int> f, Color c)
        {
            this.c = c;
            this.f = f;
            Bits = new DirectBitmap(Settings.HistogramWidth, Settings.HistogramHeight);
            Vals = new int[256];
            for (int i = 0; i < 256; i++)
            {
                Vals[i] = 0;
            }
        }
        public void Update(DirectBitmap source, DirectBitmap output, CellType[,] current)
        {
            CalculateHistogramValues(source, output, current);
            UpdateHistogramBitmap();
        }
        private void CalculateHistogramValues(DirectBitmap source, DirectBitmap output, CellType[,] current)
        {
            for (int i = 0; i < 256; i++)
            {
                Vals[i] = 0;
            }
            for (int i = 0; i < Settings.PictureHeigth; i++)
            {
                for (int j = 0; j < Settings.PictureWidth; j++)
                {
                    if (current[i, j] == CellType.Applied || current[i, j] == CellType.Other)
                    {
                        Vals[f(output.GetPixel(i, j))]++;
                    }
                    else
                    {
                        Vals[f(source.GetPixel(i, j))]++;
                    }
                }
            }
        }
        private void UpdateHistogramBitmap()
        {
            int max = Vals.Max();
            for(int i = 0; i < Settings.HistogramHeight; i++)
            {
                for(int j = 0; j < 256; j++)
                {
                    Color c = Vals[j] * Settings.HistogramHeight <= i * max ? Color.White : this.c;
                    Bits.SetPixel(j + Settings.HistogramMargin, Settings.HistogramHeight - i - 1, c);
                }
            }
        }
    }
}
