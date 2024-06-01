using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Triangle:Polygon
    {
        public Triangle(PointF[] points)
        {
            this.points = points;
            this.count = 3;
        }
    }
}
