using System.Drawing;

namespace PolyDraw
{
    public partial class MainWindowForm : Form
    {
        public Random random;
        public Bitmap bitmap;
        public List<Polygon> polygons;
        public Polygon? selectedPolygon;
        public Edge? selectedEdge;
        public Vertex? selectedVertex;
        public PointF mouse;
        public MainWindowForm()
        {
            InitializeComponent();
            polygons = new List<Polygon>();
            bitmap = new Bitmap(800, 800);
            random = new(DateTime.Now.Millisecond);
            mouse = new PointF(0, 0);
            for(int i = 0; i < 3; i++)
            {
                polygons.Add(new Polygon(random, random.Next(3,8)));
            }
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using var g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            foreach (var p in polygons)
            {
                p.Draw(bitmap, Color.Black);
            }
            selectedEdge?.Draw(bitmap, Color.Red);
            selectedPolygon?.Draw(bitmap, Color.Red);
            selectedVertex?.Draw(bitmap, Color.Red);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CreateRadioButton.Checked)
            {
                MouseDownLeftCreate(e.Location);
            }
            else if(e.Button == MouseButtons.Right && CreateRadioButton.Checked)
            {
                MouseDownRightCreate(e.Location);
            }
            else if(e.Button == MouseButtons.Left && MoveRadioButton.Checked)
            {
                MouseDownLeftMove(e.Location);
            }
            else if(e.Button == MouseButtons.Right && MoveRadioButton.Checked)
            {
                MouseDownRightMove(e.Location);
            }         
            MainPictureBox.Invalidate();
        }
        private void MouseDownLeftCreate(PointF point)
        {
            if(selectedPolygon == null)
            {
                var p = new Polygon();
                p.AddVertex(new Vertex(point));
                selectedPolygon = p;
                polygons.Add(p);
            }
            else
            {
                selectedPolygon.AddVertex(new Vertex(point));
            }
        }
        private void MouseDownRightCreate(PointF point)
        {
            selectedPolygon = null;
        }
        private void MouseDownLeftMove(PointF point)
        {
            mouse = point;
        }
        private void MouseDownRightMove(PointF point)
        {
            SelectObject(point);
        }
        private void SelectObject(PointF point)
        {
            selectedVertex = null;
            selectedEdge = null;
            selectedPolygon = null;
            foreach (var p in polygons)
            {
                foreach(var v in p.vertices)
                {
                    if (v.CheckCollision(point))
                    {
                        selectedVertex = v;
                        return;
                    }
                }
                foreach(var e in p.edges)
                {
                    if (e.CheckCollision(point))
                    {
                        selectedEdge = e;
                        return;
                    }
                }
                if (p.CheckCollision(point))
                {
                    selectedPolygon = p;
                    return;
                }
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MoveRadioButton.Checked)
            {
                if (selectedVertex != null)
                {
                    selectedVertex.location.X += e.X - mouse.X;
                    selectedVertex.location.Y += e.Y - mouse.Y;
                }
                if (selectedEdge != null)
                {
                    selectedEdge.v1.location.X += e.X - mouse.X;
                    selectedEdge.v1.location.Y += e.Y - mouse.Y;
                    selectedEdge.v2.location.X += e.X - mouse.X;
                    selectedEdge.v2.location.Y += e.Y - mouse.Y;
                }
                if (selectedPolygon != null)
                {
                    foreach(var v in selectedPolygon.vertices)
                    {
                        v.location.X += e.X - mouse.X;
                        v.location.Y += e.Y - mouse.Y;
                    }
                }
                mouse = e.Location;
                MainPictureBox.Invalidate();
            }
        }

        private void RandomPolygonButton_Click(object sender, EventArgs e)
        {
            polygons.Add(new Polygon(random, random.Next(3, 8)));
            MainPictureBox.Invalidate();
        }

        private void RemoveAllButton_Click(object sender, EventArgs e)
        {
            polygons.Clear();
            selectedEdge = null;
            selectedEdge = null;
            selectedPolygon = null;
            MainPictureBox.Invalidate();
        }

        private void RemoveEdgeButton_Click(object sender, EventArgs e)
        {
            if(selectedEdge == null)
            {
                return;
            }
            foreach(var p in polygons)
            {
                if (p.edges.Contains(selectedEdge))
                {
                    p.RemoveEdge(selectedEdge);
                }
            }
            selectedEdge = null;
            MainPictureBox.Invalidate();
        }
        private void RemoveVertexButton_Click(object sender, EventArgs e)
        {
            if(selectedVertex == null)
            {
                return;
            }
            foreach (var p in polygons)
            {
                if (p.vertices.Contains(selectedVertex))
                {
                    p.RemoveVertex(selectedVertex);
                }
            }
            selectedVertex = null;
            MainPictureBox.Invalidate();
        }
        private void RemovePolygonButton_Click(object sender, EventArgs e)
        {
            if(selectedPolygon == null)
            {
                return;
            }
            polygons.Remove(selectedPolygon);
            selectedPolygon = null;
            MainPictureBox.Invalidate();
        }

        private void DivideEdgeButton_Click(object sender, EventArgs e)
        {
            if(selectedEdge == null)
            {
                return;
            }
            foreach (var p in polygons)
            {
                if (p.edges.Contains(selectedEdge))
                {
                    var vert = new Vertex(new PointF((selectedEdge.v1.location.X + selectedEdge.v2.location.X) / 2, (selectedEdge.v1.location.Y + selectedEdge.v2.location.Y) / 2));
                    var edge = new Edge(vert, selectedEdge.v2);
                    int index = p.edges.IndexOf(selectedEdge);
                    selectedEdge.v2 = vert;
                    p.edges.Insert(index + 1, edge);
                    p.vertices.Insert(index + 1, vert);
                }
            }
            MainPictureBox.Invalidate();
            return;
        }
    }
}