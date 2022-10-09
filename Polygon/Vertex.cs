using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{
    internal class Vertex
    {
        private Point point;
        public const int radius = 10;

        public Vertex(Point point)
        {
            this.point = point;
        }
        public Point Point
        {
            set { point = value; }
            get { return point; }
        }
    }
}
