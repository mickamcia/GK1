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
        public List<Edge> relationCandidate; 
        public List<Relation> relations;
        public MainWindowForm()
        {
            InitializeComponent();
            polygons = new List<Polygon>();
            relationCandidate = new List<Edge>();
            bitmap = new Bitmap(800, 800);
            random = new(DateTime.Now.Millisecond);
            mouse = new PointF(0, 0);
            relations = new List<Relation>();
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    polygons.Add(new Polygon(new PointF(100 + 200 * i, 100 + 200 * j), 80, 6));
                }
            }
            var e1 = new List<Edge>();
            var e2 = new List<Edge>();
            foreach (var p in polygons)
            {
                e1.Add(p.edges[0]);
                e1.Add(p.edges[3]);
                e2.Add(p.edges[2]);
            }
            relations.Add(new LengthRelation(e1));
            relations.Add(new ParallelityRelation(e2));
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            using var g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            foreach (var p in polygons)
            {
                p.Draw(bitmap, Color.Black, BresenhamLine.Checked);
            }
            foreach (var r in relations)
            {
                r.Draw(bitmap);
            }
            selectedEdge?.Draw(bitmap, Color.Red, BresenhamLine.Checked);
            selectedPolygon?.Draw(bitmap, Color.Red, BresenhamLine.Checked);
            selectedVertex?.Draw(bitmap, Color.Red);
            foreach (var p in relationCandidate)
            {
                p.Draw(bitmap, Color.LightBlue, BresenhamLine.Checked);
            }
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
                p.AddVertex(new Vertex(point, p));
                selectedPolygon = p;
                polygons.Add(p);
            }
            else
            {
                selectedPolygon.AddVertex(new Vertex(point, selectedPolygon));
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
            Edge? e = SelectEdge(point);
            if(e == null || relationCandidate.Contains(e) || e.relation != null)
            {
                return;
            }
            relationCandidate.Add(e);
        }
        private void MouseDownRightRelate(PointF point)
        {
            SelectObject(point);
            selectedPolygon = null;
            selectedVertex = null;
            relationCandidate.Clear();
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
        private Edge? SelectEdge(PointF point)
        {
            foreach (var p in polygons)
            {
                foreach (var e in p.edges)
                {
                    if (e.CheckCollision(point))
                    {
                        return e;
                    }
                }
            }
            return null;
        }
        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MoveRadioButton.Checked)
            {
                if (selectedVertex != null)
                {
                    selectedVertex.location.X += e.X - mouse.X;
                    selectedVertex.location.Y += e.Y - mouse.Y;
                    selectedVertex.fix = true;
                    int index = selectedVertex.parent.vertices.IndexOf(selectedVertex);
                    int count = selectedVertex.parent.edges.Count;
                    selectedVertex.parent.edges[index].relation?.ForceRelation(selectedVertex);
                    selectedVertex.parent.edges[(index + count - 1) % count].relation?.ForceRelation(selectedVertex);
                }
                if (selectedEdge != null)
                {
                    selectedEdge.v1.location.X += e.X - mouse.X;
                    selectedEdge.v1.location.Y += e.Y - mouse.Y;
                    selectedEdge.v2.location.X += e.X - mouse.X;
                    selectedEdge.v2.location.Y += e.Y - mouse.Y;
                    selectedEdge.v1.fix = true;
                    selectedEdge.v2.fix = true;
                    int index = selectedEdge.parent.edges.IndexOf(selectedEdge);
                    int count = selectedEdge.parent.edges.Count;
                    selectedEdge.parent.edges[(index + 1) % count].relation?.ForceRelation(selectedEdge.parent.vertices[(index + 1) % count]);
                    selectedEdge.parent.edges[(index + count - 1) % count].relation?.ForceRelation(selectedEdge.parent.vertices[(index + count - 1) % count]);
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
            relations.Clear();
            polygons.Clear();
            selectedEdge = null;
            selectedVertex = null;
            selectedPolygon = null;
            MainPictureBox.Invalidate();
        }

        private void RemoveEdgeButton_Click(object sender, EventArgs e)
        {
            if(selectedEdge == null)
            {
                return;
            }
            Relation.ClearNeighbours(relations, selectedEdge);
            selectedEdge.parent.RemoveEdge(selectedEdge);
            selectedEdge = null;
            MainPictureBox.Invalidate();
        }
        private void RemoveVertexButton_Click(object sender, EventArgs e)
        {
            if(selectedVertex == null)
            {
                return;
            }
            Relation.ClearNeighbours(relations, selectedVertex);
            selectedVertex.parent.RemoveVertex(selectedVertex);
            selectedVertex = null;
            MainPictureBox.Invalidate();
        }
        private void RemovePolygonButton_Click(object sender, EventArgs e)
        {
            if(selectedPolygon == null)
            {
                return;
            }
            foreach(var v in selectedPolygon.vertices)
            {
                Relation.ClearNeighbours(relations, v);
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
            Polygon p = selectedEdge.parent;
            var vert = new Vertex(Tools.EdgeMidPoint(selectedEdge), p);
            var edge = new Edge(vert, selectedEdge.v2, p);
            int index = p.edges.IndexOf(selectedEdge);
            selectedEdge.v2 = vert;
            p.edges.Insert(index + 1, edge);
            p.vertices.Insert(index + 1, vert);
            Relation.ClearNeighbours(relations, vert);
            MainPictureBox.Invalidate();
            return;
        }

        private void BresenhamLine_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Invalidate();
        }
        private void UpdateButtons()
        {
            ClearRelationsButton.Enabled = relations.Count > 0;
            RemoveAllButton.Enabled = polygons.Count > 0;
            RemovePolygonButton.Enabled = selectedPolygon != null;
            DivideEdgeButton.Enabled = selectedEdge != null;
            RandomPolygonButton.Enabled = true;
            RemoveEdgeButton.Enabled = selectedEdge != null && selectedEdge.parent.vertices.Count > 4;
            RemoveVertexButton.Enabled = selectedVertex != null && selectedVertex.parent.vertices.Count > 3;

            LengthRelationButton.Enabled = false;
            ParallelityRelationButton.Enabled = false;
            RemoveRelationButton.Enabled = selectedEdge != null && selectedEdge.relation != null;
            if (RelationRadioButton.Checked)
            {
                LengthRelationButton.Enabled = relationCandidate.Count >= 2;
                ParallelityRelationButton.Enabled = relationCandidate.Count >= 2;
            }
        }

        private void RelationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LengthRelationButton.Enabled = RemoveRelationButton.Enabled = ParallelityRelationButton.Enabled = RelationRadioButton.Checked;
            selectedPolygon = null;
            selectedVertex = null;
            if(RelationRadioButton.Checked == false)
            {
                relationCandidate.Clear();
            }
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
            if(relationCandidate.Count < 2)
            {
                return;
            }
            relations.Add(new LengthRelation(new List<Edge>(relationCandidate)));
            relationCandidate.Clear();
            MainPictureBox.Invalidate();
        }

        private void PerpendicularityRelationButton_Click(object sender, EventArgs e)
        {
            if (relationCandidate.Count < 2)
            {
                return;
            }
            relations.Add(new ParallelityRelation(new List<Edge>(relationCandidate)));
            relationCandidate.Clear();
            MainPictureBox.Invalidate();
        }

        private void RemoveRelationButton_Click(object sender, EventArgs e)
        {
            if(selectedEdge == null)
            {
                return;
            }
            for (int i = 0; i < relations.Count; i++)
            {
                if (relations[i].edges.Contains(selectedEdge))
                {
                    foreach(var edge in relations[i].edges)
                    {
                        edge.relation = null;
                    }
                    relations.RemoveAt(i);
                }
            }
            selectedEdge = null;
            MainPictureBox.Invalidate();
        }
        private void ClearRelationsButton_Click(object sender, EventArgs e)
        {
            foreach (var r in relations)
            {
                foreach (var edge in r.edges)
                {
                    edge.relation = null;
                }
            }
            relations.Clear();
            MainPictureBox.Invalidate();
        }
    }
}