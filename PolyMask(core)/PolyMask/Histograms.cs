using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMask
{
    public class Histograms
    {
        private DirectBitmap redBits;
        private DirectBitmap greenBits;
        private DirectBitmap blueBits;
        private DirectBitmap combBits;
        private int[] redVals;
        private int[] greenVals;
        private int[] blueVals;
        private int[] combVals;
        public Histograms()
        {
            redBits = new DirectBitmap(Settings.HistogramWidth, Settings.HistogramHeight);
            greenBits = new DirectBitmap(Settings.HistogramWidth, Settings.HistogramHeight);
            blueBits = new DirectBitmap(Settings.HistogramWidth, Settings.HistogramHeight);
            combBits = new DirectBitmap(Settings.HistogramWidth, Settings.HistogramHeight);
            redVals = new int[256];
            greenVals = new int[256];
            blueVals = new int[256];
            combVals = new int[256];
            for (int i = 0; i < 256; i++)
            {
                redVals[i] = 0;
                greenVals[i] = 0;
                blueVals[i] = 0;
                combVals[i] = 0;
            }
        }
        public void CalculateHistogramValues(DirectBitmap source, DirectBitmap output, CellType[,] current)
        {
            for (int i = 0; i < 256; i++)
            {
                redVals[i] = 0;
                greenVals[i] = 0;
                blueVals[i] = 0;
                combVals[i] = 0;
            }
            for (int i = 0; i < Settings.PictureHeigth; i++)
            {
                for (int j = 0; j < Settings.PictureWidth; j++)
                {
                    if (current[i,j] == CellType.Visible)
                    {
                        redVals[output.GetPixel(i, j).R]++;
                        greenVals[output.GetPixel(i, j).G]++;
                        blueVals[output.GetPixel(i, j).B]++;
                        
                    }
                    else
                    {
                        redVals[source.GetPixel(i, j).R]++;
                        greenVals[source.GetPixel(i, j).G]++;
                        blueVals[source.GetPixel(i, j).B]++;
                    }
                }
            }
        }
    }
}
