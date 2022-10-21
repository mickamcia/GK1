using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PolyDraw
{
    public abstract class Relation
    {
        public abstract Brush brush
        {
            get;
        }
        public const int radius = 10;
        private static int count = 0;
        public Edge e1;
        public Edge e2;
        public int index;
        public Relation(Edge e1, Edge e2)
        {
            index = count++;
            this.e1 = e1;
            this.e2 = e2;
            e1.relation = this;
            e2.relation = this;
        }
        public abstract void ForceRelation(Edge selectedEdge);
        public void Draw(Bitmap bitmap)
        {
            using Graphics g = Graphics.FromImage(bitmap);
            PointF p = Tools.EdgeMidPoint(e2);
            g.FillEllipse(brush, p.X - radius, p.Y - radius, radius * 2, radius * 2);
            g.DrawString(index.ToString(), new Font("Tahoma", 14), Brushes.Black, p);
            p = Tools.EdgeMidPoint(e1);
            g.FillEllipse(brush, p.X - radius, p.Y - radius, radius * 2, radius * 2);
            g.DrawString(index.ToString(), new Font("Tahoma", 14), Brushes.Black, p);
        }
        public static void ClearNeighbours(List<Relation> relations, Vertex v)
        {
            int index = v.parent.vertices.IndexOf(v);
            int count = v.parent.vertices.Count;
            var r = v.parent.edges[index].relation;
            if (r != null && relations.Contains(r))
            {
                relations.Remove(r);
            }
            r = v.parent.edges[(index + count - 1) % count].relation;
            if (r != null && relations.Contains(r))
            {
                relations.Remove(r);
            }
        }
        public static void ClearNeighbours(List<Relation> relations, Edge e)
        {
            ClearNeighbours(relations, e.v1);
            ClearNeighbours(relations, e.v2);
        }
    }
    public class LengthRelation : Relation
    {
        public Brush _brush;
        public LengthRelation(Edge e1, Edge e2) : base(e1, e2)
        {
            _brush = new SolidBrush(Color.FromArgb(100, Color.Green));
        }

        public override Brush brush => _brush;

        public override void ForceRelation(Edge selectedEdge)
        {
            throw new NotImplementedException();
        }
    }
    public class ParallelityRelation : Relation
    {
        public Brush _brush;
        public ParallelityRelation(Edge e1, Edge e2) : base(e1, e2)
        {
            _brush = new SolidBrush(Color.FromArgb(100, Color.Yellow));
        }

        public override Brush brush => _brush;

        public override void ForceRelation(Edge selectedEdge)
        {
            throw new NotImplementedException();
        }
    }
}
