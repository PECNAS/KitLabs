using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Circle : Ellipse
    {
        public Circle(int x=0, int y=0, int r=50)
        {
            this.x = x;
            this.y = y;
            this.w = r;
            this.h = r;
        }
    }
}
