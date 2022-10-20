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
        public List<(Vertex v1, Vertex v2)> lengthRelations;
        public List<(Edge e1, Edge? e2)> perpendicularRelations;
        public MainWindowForm()
        {
            InitializeComponent();
            polygons = new List<Polygon>();
            bitmap = new Bitmap(800, 800);
            random = new(DateTime.Now.Millisecond);
            mouse = new PointF(0, 0);
            lengthRelations = new List<(Vertex v1, Vertex v2)>();
            perpendicularRelations = new List<(Edge v1, Edge? v2)>();
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
                p.Draw(bitmap, Color.Black, BresenhamLine.Checked);
            }
            RectangleF rect = new();
            rect.Width = Vertex.radius * 4;
            rect.Height = Vertex.radius * 4;
            for (int i = 0; i < lengthRelations.Count; i++)
            {
                rect.X = (lengthRelations[i].v1.location.X + lengthRelations[i].v2.location.X) / 2 - Vertex.radius * 2;
                rect.Y = (lengthRelations[i].v1.location.Y + lengthRelations[i].v2.location.Y) / 2 - Vertex.radius * 2;
                g.FillEllipse(Brushes.Yellow, rect);
                g.DrawString(i.ToString(), new Font("Tahoma", 14), Brushes.Black, rect);
            }
            for (int i = 0; i < perpendicularRelations.Count; i++)
            {
                rect.X = (perpendicularRelations[i].e1.v1.location.X + perpendicularRelations[i].e1.v2.location.X) / 2 - Vertex.radius * 2;
                rect.Y = (perpendicularRelations[i].e1.v1.location.Y + perpendicularRelations[i].e1.v2.location.Y) / 2 - Vertex.radius * 2;
                g.FillEllipse(Brushes.Green, rect);
                g.DrawString(i.ToString(), new Font("Tahoma", 14), Brushes.Black, rect);
                if(perpendicularRelations[i].e2 != null)
                {
                    rect.X = (perpendicularRelations[i].e2.v1.location.X + perpendicularRelations[i].e2.v2.location.X) / 2 - Vertex.radius * 2;
                    rect.Y = (perpendicularRelations[i].e2.v1.location.Y + perpendicularRelations[i].e2.v2.location.Y) / 2 - Vertex.radius * 2;
                    g.FillEllipse(Brushes.Green, rect);
                    g.DrawString(i.ToString(), new Font("Tahoma", 14), Brushes.Black, rect);
                }
            }
            selectedEdge?.Draw(bitmap, Color.Red, BresenhamLine.Checked);
            selectedPolygon?.Draw(bitmap, Color.Red, BresenhamLine.Checked);
            selectedVertex?.Draw(bitmap, Color.Red);
            e.Graphics.DrawImage(bitmap, 0, 0);
            UpdateButtons();
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
            else if (e.Button == MouseButtons.Left && RelationRadioButton.Checked)
            {
                MouseDownLeftRelate(e.Location);
            }
            else if (e.Button == MouseButtons.Right && RelationRadioButton.Checked)
            {
                MouseDownRightRelate(e.Location);
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
        private void MouseDownLeftRelate(PointF point)
        {

        }
        private void MouseDownRightRelate(PointF point)
        {
            SelectObject(point);
            selectedPolygon = null;
            selectedVertex = null;
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
            lengthRelations.Clear();
            perpendicularRelations.Clear();
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

        private void BresenhamLine_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Invalidate();
        }
        private void UpdateButtons()
        {
            ClearRelationsButton.Enabled = (lengthRelations.Count > 0 || perpendicularRelations.Count > 0);
            if (RelationRadioButton.Checked)
            {
                LengthRelationButton.Enabled = PerpendicularityRelationButton.Enabled = selectedEdge != null;
                RemoveRelationButton.Enabled = false;
                if (selectedEdge != null)
                {
                    foreach (var r in lengthRelations)
                    {
                        if (r.v1 == selectedEdge.v1 && r.v2 == selectedEdge.v2)
                        {
                            LengthRelationButton.Enabled = false;
                            PerpendicularityRelationButton.Enabled = false;
                            RemoveRelationButton.Enabled = true;
                        }
                    }
                    foreach (var r in perpendicularRelations)
                    {
                        if (r.e1 == selectedEdge || r.e2 == selectedEdge)
                        {
                            LengthRelationButton.Enabled = false;
                            PerpendicularityRelationButton.Enabled = false;
                            RemoveRelationButton.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                LengthRelationButton.Enabled = false;
                PerpendicularityRelationButton.Enabled = false;
                RemoveRelationButton.Enabled = false;
            }
            if(selectedVertex != null)
            {
                foreach(var p in polygons)
                {
                    if (p.vertices.Contains(selectedVertex))
                    {
                        RemoveVertexButton.Enabled = p.vertices.Count > 3;
                    }
                }
            }
            else
            {
                RemoveVertexButton.Enabled = selectedVertex != null;
            }
            if (selectedEdge != null)
            {
                foreach (var p in polygons)
                {
                    if (p.edges.Contains(selectedEdge))
                    {
                        RemoveEdgeButton.Enabled = p.edges.Count > 4;
                    }
                }
            }
            else
            {
                RemoveEdgeButton.Enabled = selectedEdge != null;
            }
            RemoveAllButton.Enabled = polygons.Count > 0;
            RemovePolygonButton.Enabled = selectedPolygon != null;
            DivideEdgeButton.Enabled = selectedEdge != null;
        }

        private void RelationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LengthRelationButton.Enabled = RemoveRelationButton.Enabled = PerpendicularityRelationButton.Enabled = RelationRadioButton.Checked;
            selectedPolygon = null;
            selectedVertex = null;
            MainPictureBox.Invalidate();
        }

        private void MoveRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            selectedPolygon = null;
            selectedEdge = null;
            selectedVertex = null;
            MainPictureBox.Invalidate();
        }

        private void LengthRelationButton_Click(object sender, EventArgs e)
        {
            if(selectedEdge == null)
            {
                return;
            }
            foreach(var r in lengthRelations)
            {
                if (r.v1 == selectedEdge.v1 && r.v2 == selectedEdge.v2)
                {
                    return;
                }
            }
            foreach (var r in perpendicularRelations)
            {
                if (r.e1 == selectedEdge || r.e2 == selectedEdge)
                {
                    return;
                }
            }
            lengthRelations.Add((selectedEdge.v1, selectedEdge.v2));
            MainPictureBox.Invalidate();
        }

        private void PerpendicularityRelationButton_Click(object sender, EventArgs e)
        {
            if (selectedEdge == null)
            {
                return;
            }
            foreach (var r in lengthRelations)
            {
                if (r.v1 == selectedEdge.v1 && r.v2 == selectedEdge.v2)
                {
                    return;
                }
            }
            foreach (var r in perpendicularRelations)
            {
                if (r.e1 == selectedEdge || r.e2 == selectedEdge)
                {
                    return;
                }
            }
            if (perpendicularRelations.Count == 0 || perpendicularRelations[^1].e2 != null)
            {
                perpendicularRelations.Add((selectedEdge, null));
            }
            else
            {
                perpendicularRelations[^1] = (perpendicularRelations[^1].e1, selectedEdge);
            }
            MainPictureBox.Invalidate();
        }

        private void RemoveRelationButton_Click(object sender, EventArgs e)
        {
            if(selectedEdge == null)
            {
                return;
            }
            for(int i = 0; i < lengthRelations.Count; i++)
            {
                if (lengthRelations[i].v1 == selectedEdge.v1 && lengthRelations[i].v2 == selectedEdge.v2)
                {
                    lengthRelations.RemoveAt(i);
                }
            }
            for (int i = 0; i < perpendicularRelations.Count; i++)
            {
                if (perpendicularRelations[i].e1 == selectedEdge || perpendicularRelations[i].e2 == selectedEdge)
                {
                    perpendicularRelations.RemoveAt(i);
                }
            }
            selectedEdge = null;
            MainPictureBox.Invalidate();
        }

        private void ClearRelationsButton_Click(object sender, EventArgs e)
        {
            lengthRelations.Clear();
            perpendicularRelations.Clear();
            MainPictureBox.Invalidate();
        }
    }
}