using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PolyMesh
{
    //https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f
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

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
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
    internal class Utils
    {
        
        public static Model ParseModel(string path)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Model model = new();
            const Int32 BufferSize = 128;
            using var fileStream = File.OpenRead(path);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize);
            String? line;
            string[] separators = { " ", "//", "/" };
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;
                switch (parts[0])
                {
                    case "v":
                        model.vertices.Add(new Vector3((float)Convert.ToDouble(parts[1]) * Settings.modelScale + Settings.bitmapSize / 2, (float)Convert.ToDouble(parts[2]) * Settings.modelScale + Settings.bitmapSize / 2, (float)Convert.ToDouble(parts[3]) * Settings.modelScale + Settings.bitmapSize / 2));
                        break;
                    case "vn":
                        if ((float)Convert.ToDouble(parts[3]) < 0)
                        {
                            model.normals.Add(new Vector3(-(float)Convert.ToDouble(parts[1]), -(float)Convert.ToDouble(parts[2]), -(float)Convert.ToDouble(parts[3])));
                        }
                        else
                        {
                            model.normals.Add(new Vector3((float)Convert.ToDouble(parts[1]), (float)Convert.ToDouble(parts[2]), (float)Convert.ToDouble(parts[3])));
                        }
                        break;
                    case "f":
                        if (parts.Length == 7)
                        {
                            model.triangles.Add(new Triangle(model.vertices[Convert.ToInt32(parts[1]) - 1], model.vertices[Convert.ToInt32(parts[3]) - 1], model.vertices[Convert.ToInt32(parts[5]) - 1], model.normals[Convert.ToInt32(parts[2]) - 1], model.normals[Convert.ToInt32(parts[4]) - 1], model.normals[Convert.ToInt32(parts[6]) - 1]));
                        }
                        if (parts.Length == 10)
                        {
                            model.triangles.Add(new Triangle(model.vertices[Convert.ToInt32(parts[1]) - 1], model.vertices[Convert.ToInt32(parts[4]) - 1], model.vertices[Convert.ToInt32(parts[7]) - 1], model.normals[Convert.ToInt32(parts[3]) - 1], model.normals[Convert.ToInt32(parts[6]) - 1], model.normals[Convert.ToInt32(parts[9]) - 1]));
                        }
                        break;
                    default:
                        break;
                }
            }
            return model;
        }
    }
}
