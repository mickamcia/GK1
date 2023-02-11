﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace PolyView
{
    public class Model
    {
        public List<Polygon> polygons;
        public List<Vector4> vertices;
        public List<Vector3> normals;
        public Matrix4x4 modelMatrixScale;
        public Matrix4x4 modelMatrixTranslation;
        public Matrix4x4 modelMatrixRotation;
        public Matrix4x4 modelMatrix;
        public Model()
        {
            polygons = new List<Polygon>();
            vertices = new List<Vector4>();
            normals = new List<Vector3>();
        }

        internal void Paint(DirectBitmap bits)
        {
            foreach(var polygon in polygons)
            {
                if(polygon.vertices.Any(p => p.view_pos.X < 0 || p.view_pos.X >= Settings.BitmapHeight || p.view_pos.Y < 0 || p.view_pos.Y >= Settings.BitmapWidth || p.view_pos.Z < Settings.nearPlaneDist || p.view_pos.Z >= Settings.farPlaneDist))
                //if(polygon.vertices.Any(p => p.view_pos.X < -100 || p.view_pos.X >= Settings.BitmapHeight+100 || p.view_pos.Y < -100 || p.view_pos.Y >= Settings.BitmapWidth+100 || p.view_pos.Z < Settings.nearPlaneDist || p.view_pos.Z >= Settings.farPlaneDist))
                {

                }
                else
                {
                    polygon.PaintFull(bits);
                }
            }
        }
    }
    public class Vertex
    {
        public Vertex next;
        public Vertex prev;
        public Vector4 model_pos;
        public Vector3 model_norm;

        public Vector4 scene_pos;
        public Vector3 scene_norm;

        public Vector4 view_pos;
        public Vector3 view_norm;


        public AETP pointer;
        public Vertex(Vector4 position, Vector3 normal)
        {
            this.model_pos = position;
            this.model_norm = normal;
            next = prev = this;
            pointer = new AETP();
        }
        public Vertex(Vector4 position)
        {
            this.model_pos = position;
            next = prev = this;
            pointer = new AETP();
        }
    }
    public class AETP
    {
        public double startx;
        public double ymax;
        public double currx;
        public int x;
        public double one_m;
        public AETP()
        {

        }
        public void advance()
        {
            currx += one_m;
            x = (int)currx;
        }
        public void reset()
        {
            currx = startx;
            x = (int)currx;
        }
    }
    public class Polygon
    {
        public List<Vertex> vertices;

        public Polygon(Vector4 v1, Vector4 v2, Vector4 v3, Vector3 vn1, Vector3 vn2, Vector3 vn3)
        {
            vertices = new()
            {
                new Vertex(v1, vn1),
                new Vertex(v2, vn2),
                new Vertex(v3, vn3)
            };
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].next = vertices[(i + 1) % vertices.Count];
                vertices[i].prev = vertices[(i + vertices.Count - 1) % vertices.Count];
            }
            GenerateAETP();
        }
        public Polygon()
        {
            vertices = new List<Vertex>();
            
        }
        public void Finish()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].next = vertices[(i + 1) % vertices.Count];
                vertices[i].prev = vertices[(i + vertices.Count - 1) % vertices.Count];
            }
            GenerateAETP();
        }
        public void GenerateAETP()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                var temp = new AETP();
                temp.startx = vertices[i].view_pos.Y > vertices[i].next.view_pos.Y ? vertices[i].next.view_pos.X : vertices[i].view_pos.X;
                temp.currx = temp.startx;
                temp.x = (int)temp.startx;
                temp.ymax = Math.Max(vertices[i].view_pos.Y, vertices[i].next.view_pos.Y);
                temp.one_m = (vertices[i].view_pos.X - vertices[i].next.view_pos.X) / (vertices[i].view_pos.Y - vertices[i].next.view_pos.Y);
                vertices[i].pointer = temp;
            }
        }
        public void UpdateAETP()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                var temp = vertices[i].pointer;
                temp.startx = vertices[i].view_pos.Y > vertices[i].next.view_pos.Y ? vertices[i].next.view_pos.X : vertices[i].view_pos.X;
                temp.currx = temp.startx;
                temp.x = (int)temp.startx;
                temp.ymax = Math.Max(vertices[i].view_pos.Y, vertices[i].next.view_pos.Y);
                temp.one_m = (vertices[i].view_pos.X - vertices[i].next.view_pos.X) / (vertices[i].view_pos.Y - vertices[i].next.view_pos.Y);
                vertices[i].pointer = temp;
            }
        }
        public void ResetEdges()
        {
            foreach (var v in vertices)
            {
                v.pointer.reset();
            }
        }
        public void Paint(DirectBitmap bits)
        {
            foreach(var p in vertices)
            {
                line((int)p.view_pos.X, (int)p.view_pos.Y, (int)p.next.view_pos.X, (int)p.next.view_pos.Y, Color.BlueViolet, bits);
            }
        }
        void line(int x, int y, int x2, int y2, Color color, DirectBitmap bits)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if(x < 0 || y < 0 || x >= Settings.BitmapWidth || y >= Settings.BitmapHeight)
                {

                }
                else
                {
                    bits.SetPixel(x, y, color);
                }
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
        public void PaintFull(DirectBitmap bits)
        {
            ResetEdges();
            double ymax = vertices.Max(p => p.view_pos.Y);
            double ymin = vertices.Min(p => p.view_pos.Y);
            List<AETP> AET = new List<AETP>();
            for (int y = (int)ymin; y < (int)ymax; y++)
            {
                foreach (var v in vertices.Where(p => (int)p.view_pos.Y == y))
                {
                    if ((int)v.next.view_pos.Y > (int)v.view_pos.Y)
                    {
                        AET.Add(v.pointer);
                    }
                    else
                    {
                        AET.Remove(v.pointer);
                    }
                    if ((int)v.prev.view_pos.Y > (int)v.view_pos.Y)
                    {
                        AET.Add(v.prev.pointer);
                    }
                    else
                    {
                        AET.Remove(v.prev.pointer);
                    }
                }
                if (AET.Count > 0)
                {
                    FillAET(bits, AET, y);
                }
            }
        }
        private void FillAET(DirectBitmap bits, List<AETP> AET, int y)
        {
            AET.Sort(delegate (AETP p1, AETP p2)
            {
                if (p1.x <= p2.x) return 0;
                else
                    return 1;
            });
            for (int i = 0; i < AET.Count - 1; i += 2)
            {
                FillLine(bits, AET[i].x, AET[i + 1].x, y);
            }
            foreach (var ptr in AET)
            {
                ptr.advance();
            }
        }
        private void FillLine(DirectBitmap bits, int x1, int x2, int y)
        {
            for (int x = x1; x <= x2; x++)
            {
                if (x >= bits.Width || y >= bits.Height || x < 0 || y < 0) break;
                var positions = vertices.Select(p => p.view_pos).ToArray();
                var normals = vertices.Select(p => p.model_norm).ToArray();
                (float w1, float w2, float w3) bar = Lighting.GetBarycentricWeights(positions, x, y);
                float z = bar.w1 * vertices[0].view_pos.Z + bar.w2 * vertices[1].view_pos.Z + bar.w3 * vertices[2].view_pos.Z;
                
                if (z <= MainWindowForm.scene.zBuffer.data[x, y])
                {
                    MainWindowForm.scene.zBuffer.data[x, y] = z;
                    var ls = new Vector3(1000, 0, 10);//Lighting.GetLightVector((float)(Settings.frameCount / 100));
                    Color color = Color.White;
                    
                    var pos = positions[0] * bar.w1 + positions[1] * bar.w2 + positions[2] * bar.w3;
                    var nor = normals[0] * bar.w1 + normals[1] * bar.w2 + normals[2] * bar.w3;
                    var pos3 = new Vector3(pos.X, pos.Y, pos.Z);
                    color = Lighting.GetColor(ls - pos3, nor);
                    bits.SetPixel(x, y, color);
                }
            }
        }
    }
}
