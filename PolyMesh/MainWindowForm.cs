using System.Drawing;
using System.Numerics;

namespace PolyMesh
{
    public partial class MainWindowForm : Form
    {
        const string path = "C:\\Users\\s\\Source\\Repos\\mickamcia\\GK1\\PolyMesh\\sphere.obj";
        //const string path = "C:\\Users\\user\\source\\repos\\mickamcia\\GK1\\PolyMesh\\sphereXXL.obj";
        public readonly Model model;
        public readonly Bitmap bits;
        public const int bitmapSize = 800;
        public const int modelScale = 300;
        public static Vector3 LightSource = new Vector3(bitmapSize / 2, bitmapSize / 2, bitmapSize / 2);
        public static Random rnd = new();
        public MainWindowForm()
        {
            InitializeComponent();

            model = Parser.ParseModel(path);
            bits = new(bitmapSize, bitmapSize);
            MainPictureBox.Invalidate();
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            _ = model;
            using var g = Graphics.FromImage(bits);
            g.Clear(Color.White);
            foreach (var t in model.triangles)
            {
                var color = Geometry.GetColor(LightSource - t.vertices[0], t.normals[0]);
                //color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                t.PaintOld(bits, color);
            }
            if (DrawEdgesCheckBox.Checked)
            {
                foreach (var t in model.triangles)
                {
                    g.DrawLine(Pens.Black, (int)t.vertices[0].X, (int)t.vertices[0].Y, (int)t.vertices[1].X, (int)t.vertices[1].Y);
                    g.DrawLine(Pens.Black, (int)t.vertices[1].X, (int)t.vertices[1].Y, (int)t.vertices[2].X, (int)t.vertices[2].Y);
                    g.DrawLine(Pens.Black, (int)t.vertices[2].X, (int)t.vertices[2].Y, (int)t.vertices[0].X, (int)t.vertices[0].Y);
                }
            }
            e.Graphics.DrawImage(bits, 0, 0);
        }

        private void LightSourceXTrackBar_Scroll(object sender, EventArgs e)
        {
            LightSource.X = LightSourceXTrackBar.Value + bitmapSize / 2;
            MainPictureBox.Invalidate();
        }

        private void LightSourceYTrackBar_Scroll(object sender, EventArgs e)
        {
            LightSource.Y = LightSourceYTrackBar.Value + bitmapSize / 2;
            MainPictureBox.Invalidate();
        }

        private void LightSourceZTrackBar_Scroll(object sender, EventArgs e)
        {
            LightSource.Z = LightSourceZTrackBar.Value + bitmapSize / 2;
            MainPictureBox.Invalidate();
        }

        private void DrawEdgesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Invalidate();
        }
    }
}