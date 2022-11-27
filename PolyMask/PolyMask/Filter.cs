using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMask
{
    public enum CellType
    {
        Visible,
        Hidden,
        Unknown,
    }
    public static class Settings
    {
        public static int PictureWidth = 800;
        public static int PictureHeigth = 800;
        public static float[] Kernel = Kernels.Identity;
    }
    public static class Kernels
    {
        public static readonly float[] Identity = { 0.0f, 0.0f, 0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f };
        public static readonly float[] RidgeDetection = { -1.0f, -1.0f, -1.0f, -1.0f, 8.0f, -1.0f, -1.0f, -1.0f, -1.0f };
        public static readonly float[] Sharpen = { 0.0f, -1.0f, 0.0f, -1.0f, 5.0f, -1.0f, 0.0f, -1.0f, 0.0f };
        public static readonly float[] BoxBlur = { 1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f };
        public static readonly float[] GaussianBlur = { 0.0625f, 0.125f, 0.0625f, 0.125f, 0.25f, 0.125f, 0.0625f, 0.125f, 0.0625f };
        public static readonly float[] Emboss = { -2.0f, -1.0f, 0.0f, -1.0f, 1.0f, 1.0f, 0.0f, 1.0f, 2.0f };
        public static readonly float[] SobelLeft = { -1.0f, 0.0f, 1.0f, -2.0f, 0.0f, 2.0f, -1.0f, 0.0f, 1.0f };
        public static float[] Custom = { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f };
    }
    public static class Filter
    {
        public static void ApplyKernel(int x, int y, Bitmap source, Bitmap output, float[] kernel)
        {
            if(kernel.Length != 9)
            {
                return;
            }
            if(x <= 0 || y <= 0 || x >= Settings.PictureHeigth - 1 || y >= Settings.PictureWidth - 1)
            {
                return;
            }
            float R = 0, G = 0, B = 0;
            for(int k = 0; k < 9; k++)
            {
                Color c = source.GetPixel(x + k % 3 - 1, y + k / 3 - 1);
                R += c.R * kernel[k];
                G += c.G * kernel[k];
                B += c.B * kernel[k];
            }
            R = R < 0 ? 0 : R > 255 ? 255 : R;
            G = G < 0 ? 0 : G > 255 ? 255 : G;
            B = B < 0 ? 0 : B > 255 ? 255 : B;
            output.SetPixel(x, y, Color.FromArgb(255, (int)R, (int)G, (int)B));
        }
        public static void ClearBitmap(Bitmap bits)
        {
            Color c = Color.FromArgb(0,0,0,0);
            for(int i = 0; i < Settings.PictureHeigth; i++)
            {
                for(int j = 0; j < Settings.PictureWidth; j++)
                {
                    bits.SetPixel(i, j, c);
                }
            }
        }
    }
}
