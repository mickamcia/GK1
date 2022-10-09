using System.Drawing;

namespace PolyDraw
{
    public partial class MainWindowForm : Form
    {
        private readonly Bitmap bits;
        private readonly List<Polygon> polygons;

        public MainWindowForm()
        {
            InitializeComponent();
            bits = new Bitmap(800, 800);
            polygons = new List<Polygon>();
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using var g = Graphics.FromImage(bits);
            g.Clear(Color.White);
            foreach (var x in polygons)
            {
                x.Draw(g);
            }
            e.Graphics.DrawImage(bits, 0, 0);
        }

        private void MainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (CreateRadioButton.Checked && e.Button == MouseButtons.Right)
            {
                HandleCreateRight(sender, e);
            }
            if (CreateRadioButton.Checked && e.Button == MouseButtons.Left)
            {
                HandleCreateLeft(sender, e);
            }
            if (EditRadioButton.Checked && e.Button == MouseButtons.Left)
            {
                HandleEditLeft(sender, e);
            }
            if (EditRadioButton.Checked && e.Button == MouseButtons.Right)
            {
                HandleEditRight(sender, e);
            }
        }
        private void HandleEditLeft(object sender, MouseEventArgs e)
        {
            DeselectAll();
            SelectObject(e.Location);
            MainPictureBox.Invalidate();
        }
        private void HandleEditRight(object sender, MouseEventArgs e)
        {
            DeselectAll();
            MainPictureBox.Invalidate();
        }
        private void HandleCreateRight(object sender, MouseEventArgs e)
        {
            DeselectAll();
            MainPictureBox.Invalidate();
        }
        private void HandleCreateLeft(object sender, MouseEventArgs e)
        {
            foreach (var x in polygons)
            {
                if (x.selected)
                {
                    if (x.finished)
                    {

                    }
                    else
                    {
                        x.AddVertexAt(e.Location);
                    }
                    MainPictureBox.Invalidate();
                    return;
                }
            }
            polygons.Add(new Polygon(new Vertex(e.Location)));
            MainPictureBox.Invalidate();
        }
        private void DeselectAll()
        {
            foreach (var polygon in polygons)
            {
                polygon.finished = true;
                polygon.selected = false;
                foreach (var vertex in polygon.vertices)
                {
                    vertex.selected = false;
                }
            }
        }
        private bool SelectObject(Point point)
        {
            return SelectPoint(point);
        }
        private bool SelectPoint(Point point)
        {
            foreach(var polygon in polygons)
            {
                foreach(var vertex in polygon.vertices)
                {
                    if(Tools.GetDistanceSquared(vertex.point, point) < Vertex.radius * Vertex.radius)
                    {
                        vertex.selected = true;
                        polygon.selected = true;
                        UpdateButtons();
                        return true;
                    }
                }
            }
            UpdateButtons();
            return false;
        }
        private void UpdateButtons()
        {
            DeletePolygonButton.Enabled = false;
            DeleteVertexButton.Enabled = false;
            foreach (var polygon in polygons)
            {
                foreach (var vertex in polygon.vertices)
                {
                    if(vertex.selected && polygon.vertices.Count > 3)
                    {
                        DeleteVertexButton.Enabled = true;
                    }
                }
                if (polygon.selected)
                {
                    DeletePolygonButton.Enabled = true;
                }
            }
        }
        private void EditRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void DeleteVertexButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < polygons.Count; i++)
            {
                for(int j = 0; j < polygons[i].vertices.Count; j++)
                {
                    if (polygons[i].vertices[j].selected)
                    {
                        polygons[i].vertices.RemoveAt(j);
                        UpdateButtons();
                        MainPictureBox.Invalidate();
                        return;
                    }
                }
            }
        }

        private void DeletePolygonButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                if (polygons[i].selected)
                {
                    polygons.RemoveAt(i);
                    UpdateButtons();
                    MainPictureBox.Invalidate();
                    return;
                }
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!EditRadioButton.Checked || e.Button != MouseButtons.Left) return;
            foreach (var polygon in polygons)
            {
                foreach (var vertex in polygon.vertices)
                {
                    if (vertex.selected)
                    {
                        vertex.point = e.Location;
                        MainPictureBox.Invalidate();
                    }
                }
            }
        }
    }
}