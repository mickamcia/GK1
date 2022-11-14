using System.Drawing;

namespace PolyMesh
{
    public partial class MainWindowForm : Form
    {
        const string path = "C:\\Users\\s\\Source\\Repos\\mickamcia\\GK1\\PolyMesh\\sphere.obj";
        public readonly Model model;
        public Bitmap bits;
        const int size = 800;
        const int scale = 400;
        public static Vertex source = new Vertex(0,0,0);
        public static Random rnd = new();
        public MainWindowForm()
        {
            InitializeComponent();

            model = Parser.ParseModel(path);
            foreach (var v in model.vertices)
            {
                v.x = v.x * scale + size / 2;
                v.y = v.y * scale + size / 2;
                v.z = v.z * scale + size / 2;
            }
            bits = new(size, size);
            MainPictureBox.Invalidate();
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using var g = Graphics.FromImage(bits);
            g.Clear(Color.White);
            foreach (var v in model.vertices)
            {
                bits.SetPixel((int)v.x, (int)v.y, Color.Black);
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
            source.x = LightSourceXTrackBar.Value;
            MainPictureBox.Invalidate();
        }

        private void LightSourceYTrackBar_Scroll(object sender, EventArgs e)
        {
            source.y = LightSourceYTrackBar.Value;
            MainPictureBox.Invalidate();
        }

        private void LightSourceZTrackBar_Scroll(object sender, EventArgs e)
        {
            source.z = LightSourceZTrackBar.Value;
            MainPictureBox.Invalidate();
        }
    }
}