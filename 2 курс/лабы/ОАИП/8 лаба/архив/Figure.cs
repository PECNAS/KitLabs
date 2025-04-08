using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    abstract public class Figure
    {
        public int x, y, h, w; // объявляем переменные, характеризующие фигуру
        
        abstract public void draw();
        abstract public void move_to(int x, int y);
        abstract public bool move_check(int x, int y);

        public void drop_figure(Figure f)
        {

        }

        public void clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }

    }
}
