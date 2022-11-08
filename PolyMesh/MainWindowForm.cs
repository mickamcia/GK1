using System.Drawing;

namespace PolyMesh
{
    public partial class MainWindowForm : Form
    {
        const string path = "C:\\Users\\s\\Source\\Repos\\mickamcia\\GK1\\PolyMesh\\sphere.obj";
        public List<Vertex> vertices;
        public List<Edge> edges;
        public Bitmap bits;
        public MainWindowForm()
        {
            InitializeComponent();
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            bits = new(800, 800);
            for(int i = 0; i < Data.Raw.Length; i+=3)
            {
                vertices.Add(new Vertex(Data.Raw[i], Data.Raw[i + 1], Data.Raw[i + 2]));
            }
            for (int i = 0; i < Data.Pairs.Length; i += 6)
            {
                edges.Add(new Edge(vertices[Data.Pairs[i] - 1], vertices[Data.Pairs[i + 2] - 1]));
                edges.Add(new Edge(vertices[Data.Pairs[i + 2] - 1], vertices[Data.Pairs[i + 4] - 1]));
                edges.Add(new Edge(vertices[Data.Pairs[i + 4] - 1], vertices[Data.Pairs[i] - 1]));
            }
            MainPictureBox.Invalidate();
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using var g = Graphics.FromImage(bits);
            g.Clear(Color.White);
            foreach (var v in vertices)
            {
                bits.SetPixel((int)(v.a * 400) + 400, (int)(v.b * 400) + 400, Color.Black);
            }
            foreach (var uv in edges)
            {
                g.DrawLine(Pens.Black, (int)(uv.v1.a * 400) + 400, (int)(uv.v1.b * 400) + 400, (int)(uv.v2.a * 400) + 400, (int)(uv.v2.b * 400) + 400);
            }
            e.Graphics.DrawImage(bits, 0, 0);
        }
    }
}