using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Cat : Figure
    {
        public Triangle ear1;
        public Triangle ear2;
        public Ellipse head;
        PointF[] points = new PointF[3];

        public Cat(int h, int w, string name, int y, int x)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.name = name;
                
            head = new Ellipse(x, y, w, h);

            PointF[] ear1Points = new PointF[3];
            ear1Points[0] = new PointF(x + w / 3, y);
            ear1Points[1] = new PointF(x + w / 6, y - h / 3);
            ear1Points[2] = new PointF(x, y);
            ear1 = new Triangle(ear1Points);

            PointF[] ear2Points = new PointF[3];
            ear2Points[0] = new PointF(x + w * 2 / 3, y);
            ear2Points[1] = new PointF(x + w * 5 / 6, y - h / 3);
            ear2Points[2] = new PointF(x + w, y);
            ear2 = new Triangle(ear2Points);
        }

        public override void draw()
        {
            ear1.draw();
            ear2.draw();
            head.draw();
        }
        public override bool move_check(int x, int y)
        {
            if (this.ear1.move_check(x, y) && this.ear2.move_check(x, y) && this.head.move_check(x, y))
                {
                return true;
            } else
            {
                return false;
            }
        }
        public override void move_to(int x, int y)
        {
            if (this.ear1.move_check(x, y) && this.ear2.move_check(x, y) && this.head.move_check(x, y))
            {
                this.x += x;
                this.y += y;
                this.ear1.move_to(x, y);
                this.ear2.move_to(x, y);
                this.head.move_to(x, y);
            }
        }
    }
}