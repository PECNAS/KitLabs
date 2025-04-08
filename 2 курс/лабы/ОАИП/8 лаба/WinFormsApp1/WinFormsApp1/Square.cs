using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Square : Rectangle
    {
        public Square(int x, int y, int w)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = w;
        }
    }
}
