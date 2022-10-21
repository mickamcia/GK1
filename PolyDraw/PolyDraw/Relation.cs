using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        public abstract void ForceRelation(Vertex v);
        public static void ForceLength(Vertex con, Vertex help, Vertex pivit, Vertex mov)
        {
            double scale = Tools.PointDistance(con.location, help.location) / Tools.PointDistance(pivit.location, mov.location);
            if (scale == 1) return;
            mov.location.X = (float)((mov.location.X - pivit.location.X) * scale + pivit.location.X);
            mov.location.Y = (float)((mov.location.Y - pivit.location.Y) * scale + pivit.location.Y);
        }
        public static void ForceAngle(Vertex con, Vertex help, Vertex pivit, Vertex mov)
        {
            double len = Tools.PointDistance(pivit.location, mov.location);
            ForceMirror(con, help, pivit, mov);
            SetDistance(pivit, mov, len);
        }
        public static void ForceMirror(Vertex con, Vertex help, Vertex pivit, Vertex mov)
        {
            mov.location.X = help.location.X + pivit.location.X - con.location.X;
            mov.location.Y = help.location.Y + pivit.location.Y - con.location.Y;
        }
        public static void SetDistance(Vertex con, Vertex mov, double length)
        {
            double scale = length / Tools.PointDistance(con.location, mov.location);
            if (scale == 1) return;
            mov.location.X = (float)((mov.location.X - con.location.X) * scale + con.location.X);
            mov.location.Y = (float)((mov.location.Y - con.location.Y) * scale + con.location.Y);
        }
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
        public Vertex GetOppositeVertex(Vertex v)
        {
            var e = e1.v1 == v || e1.v2 == v ? e2 : e1;
            return Tools.PointDistance(e.v1.location, v.location) < Tools.PointDistance(e.v2.location, v.location) ? e.v2 : e.v1;
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

        public override void ForceRelation(Vertex con)
        {
            Vertex help, pivit, mov;
            if (con == e1.v1)
            {
                help = e1.v2;
                pivit = e2.v1;
                mov = e2.v2;
            }
            else if (con == e1.v2)
            {
                help = e1.v1;
                pivit = e2.v2;
                mov = e2.v1;
            }
            else if(con == e2.v1)
            {
                help = e2.v2;
                pivit = e1.v1;
                mov = e1.v2;
            }
            else
            {
                help = e2.v1;
                pivit = e1.v2;
                mov = e1.v1;
            }
            ForceLength(con, help, pivit, mov);
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

        public override void ForceRelation(Vertex con)
        {
            Vertex help, pivit, mov;
            if (con == e1.v1)
            {
                help = e1.v2;
                pivit = e2.v1;
                mov = e2.v2;
            }
            else if (con == e1.v2)
            {
                help = e1.v1;
                pivit = e2.v2;
                mov = e2.v1;
            }
            else if (con == e2.v1)
            {
                help = e2.v2;
                pivit = e1.v1;
                mov = e1.v2;
            }
            else
            {
                help = e2.v1;
                pivit = e1.v2;
                mov = e1.v1;
            }
            ForceAngle(con, help, pivit, mov);
        }
    }
}
