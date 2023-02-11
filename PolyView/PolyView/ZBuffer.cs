using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyView
{
    public class ZBuffer
    {
        public float[,] data;

        public ZBuffer()
        {
            data = new float[Settings.BitmapHeight, Settings.BitmapWidth];
        }
        public void Reset()
        {
            for(int i = 0; i < Settings.BitmapHeight; i++)
            {
                for(int j = 0; j < Settings.BitmapWidth; j++)
                {
                    data[i, j] = float.MaxValue;
                }
            }
        }
    }
}
