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
        private string name;
        
        abstract public void draw();
        abstract public void move_to(int x, int y);
        abstract public bool move_check(int x, int y);

        public Figure()
        {
            string t = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            this.name = this.ToString() + t;
            
        }

        public void drop_figure(Figure f, bool redraw = false)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            if (!redraw) ShapeContainer.RemoveFigure(f);
            this.clear();
            Init.pb.Image = Init.bitmap;

            for (int i = 0; i < ShapeContainer.length; i++)
            {
                ShapeContainer.figureList[i].draw();
            }
        }

        public void clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }

        public string get_name()
        {
            return this.name;
        }

    }
}
