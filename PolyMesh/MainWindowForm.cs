using System.Drawing;
using System.Numerics;

namespace PolyMesh
{
    public partial class MainWindowForm : Form
    {
        //const string path = "C:\\Users\\s\\Source\\Repos\\mickamcia\\GK1\\PolyMesh\\sphere.obj";
        const string path = "C:\\Users\\user\\source\\repos\\mickamcia\\GK1\\PolyMesh\\sphereXXL.obj";
        public readonly Model model;
        public Bitmap bits;
        public const int size = 800;
        public const int scale = 300;
        public static Vector3 source = new Vector3(size / 2, size / 2, size / 2);
        public static Random rnd = new();
        public MainWindowForm()
        {
            InitializeComponent();

            model = Parser.ParseModel(path);
            bits = new(size, size);
            MainPictureBox.Invalidate();
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            _ = model;
            using var g = Graphics.FromImage(bits);
            g.Clear(Color.White);
            foreach (var v in model.vertices)
            {
                bits.SetPixel((int)v.X, (int)v.Y, Color.Black);
            }
            /*
            foreach (var t in model.triangles)
            {
                g.DrawLine(Pens.Black, (int)t.vertices[0].x, (int)t.vertices[0].y, (int)t.vertices[1].x, (int)t.vertices[1].y);
                g.DrawLine(Pens.Black, (int)t.vertices[1].x, (int)t.vertices[1].y, (int)t.vertices[2].x, (int)t.vertices[2].y);
                g.DrawLine(Pens.Black, (int)t.vertices[2].x, (int)t.vertices[2].y, (int)t.vertices[0].x, (int)t.vertices[0].y);
            }
            */
            foreach (var t in model.triangles)
            {
                var color = Geometry.GetColor(source, t.vertices[0], t.normals[0],source);
                t.PaintOld(bits, color);
            }
            /*
            var t = model.triangles[40];
            t.Paint(bits);
            g.DrawLine(Pens.Black, (int)t.vertices[0].x, (int)t.vertices[0].y, (int)t.vertices[1].x, (int)t.vertices[1].y);
            g.DrawLine(Pens.Black, (int)t.vertices[1].x, (int)t.vertices[1].y, (int)t.vertices[2].x, (int)t.vertices[2].y);
            g.DrawLine(Pens.Black, (int)t.vertices[2].x, (int)t.vertices[2].y, (int)t.vertices[0].x, (int)t.vertices[0].y);
            */
            e.Graphics.DrawImage(bits, 0, 0);
        }

        private void LightSourceXTrackBar_Scroll(object sender, EventArgs e)
        {
            source.X = LightSourceXTrackBar.Value + size / 2;
            MainPictureBox.Invalidate();
        }

        private void LightSourceYTrackBar_Scroll(object sender, EventArgs e)
        {
            source.Y = LightSourceYTrackBar.Value + size / 2;
            MainPictureBox.Invalidate();
        }

        private void LightSourceZTrackBar_Scroll(object sender, EventArgs e)
        {
            source.Z = LightSourceZTrackBar.Value + size / 2;
            MainPictureBox.Invalidate();
        }
    }
}