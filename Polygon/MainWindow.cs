using System.Drawing;

namespace Polygon
{
    public partial class MainWindow : Form
    {
        private Bitmap bits;
        private List<LinkedList<Vertex>> polygons;
        private LinkedList<Vertex> currentPolygon;
        private bool polygonSelectedMode;

        public MainWindow()
        {
            InitializeComponent();
            bits = new Bitmap(800, 800);
            polygons = new List<LinkedList<Vertex>>();
            currentPolygon = new LinkedList<Vertex>();
            polygonSelectedMode = false;
        }

        private void BitMap_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                polygonSelectedMode = false;
                return;
            }
            else
            {
                if(polygonSelectedMode == false)
                {
                    polygonSelectedMode = true;
                    currentPolygon = new LinkedList<Vertex>();
                    polygons.Add(currentPolygon);
                }
                currentPolygon.AddLast(new Vertex(e.Location));

            }
            BitMap.Invalidate();
        }

        private void BitMap_Paint(object sender, PaintEventArgs e)
        {
            using var g = Graphics.FromImage(bits);
            g.Clear(Color.White);
            foreach (var x in polygons)
            {
                DrawPolygon(g, x);
            }
            e.Graphics.DrawImage(bits, 0, 0);
        }
        private void DrawPolygon(Graphics g, LinkedList<Vertex> x)
        {
            var points = x.Select(x => x.Point).ToArray();
            for(int i = 0; i < points.Length; i++)
            {
                g.DrawEllipse(Pens.Black, points[i].X - Vertex.radius / 2, points[i].Y - Vertex.radius / 2, Vertex.radius, Vertex.radius);
                g.DrawLine(Pens.Black, points[i], points[(i + 1) % points.Length]);
            }
        }
    }
}