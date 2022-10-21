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
        public List<Edge> edges;
        public int index;
        public Relation(List<Edge> edges)
        {
            index = count++;
            this.edges = edges;
            foreach(Edge e in edges)
            {
                e.relation = this;
            }
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
            PointF p;
            foreach(var e in edges)
            {
                p = Tools.EdgeMidPoint(e);
                g.FillEllipse(brush, p.X - radius, p.Y - radius, radius * 2, radius * 2);
                g.DrawString(index.ToString(), new Font("Tahoma", 14), Brushes.Black, p);
            }
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
        public LengthRelation(List<Edge> edges) : base(edges)
        {
            _brush = new SolidBrush(Color.FromArgb(100, Color.Green));
        }

        public override Brush brush => _brush;

        public override void ForceRelation(Vertex con)
        {
            Vertex? help = null;
            List<Vertex> pivit = new();
            List<Vertex> mov = new();
            foreach (Edge e in edges)
            {
                if (con == e.v1)
                {
                    help = e.v2;
                    pivit = edges.Select(e => e.v1).ToList();
                    mov = edges.Select(e => e.v2).ToList();
                    pivit.Remove(con);
                    mov.Remove(help);
                }
                else if (con == e.v2)
                {
                    help = e.v1;
                    pivit = edges.Select(e => e.v2).ToList();
                    mov = edges.Select(e => e.v1).ToList();
                    pivit.Remove(con);
                    mov.Remove(help);
                }
            }
            if(help == null || pivit.Count != mov.Count)
            {
                return;
            }
            for (int i = 0; i < pivit.Count; i++)
            {
                ForceLength(con, help, pivit[i], mov[i]);
            }
        }
    }
    public class ParallelityRelation : Relation
    {
        public Brush _brush;
        public ParallelityRelation(List<Edge> edges) : base(edges)
        {
            _brush = new SolidBrush(Color.FromArgb(100, Color.Yellow));
        }

        public override Brush brush => _brush;

        public override void ForceRelation(Vertex con)
        {
            Vertex? help = null;
            List<Vertex> pivit = new();
            List<Vertex> mov = new();
            foreach (Edge e in edges)
            {
                if (con == e.v1)
                {
                    help = e.v2;
                    pivit = edges.Select(e => e.v1).ToList();
                    mov = edges.Select(e => e.v2).ToList();
                    pivit.Remove(con);
                    mov.Remove(help);
                }
                else if (con == e.v2)
                {
                    help = e.v1;
                    pivit = edges.Select(e => e.v2).ToList();
                    mov = edges.Select(e => e.v1).ToList();
                    pivit.Remove(con);
                    mov.Remove(help);
                }
            }
            if (help == null || pivit.Count != mov.Count)
            {
                return;
            }
            for (int i = 0; i < pivit.Count; i++)
            {
                ForceAngle(con, help, pivit[i], mov[i]);
            }
        }
    }
}
