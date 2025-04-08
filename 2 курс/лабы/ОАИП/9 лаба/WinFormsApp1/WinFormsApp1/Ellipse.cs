using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Ellipse : Figure
    {
        public Ellipse(int x=0, int y=0, int w=40, string name="Ellipse")
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = w;
            this.name = name;
        }

        public override void draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(
                Init.pen,
                new RectangleF(
                        this.x,
                        this.y,
                        this.w,
                        this.h)
                    );

            Init.pb.Image = Init.bitmap;
        }

        public override bool move_check(int x, int y)
        {
            // функция проверяет, можно ли переместить фигуру на заданные координаты
            // в качестве ответа идет булевое значение. true - можно переместить, false - нельзя переместить

            bool lls = this.x + x < 0; // выход за границу левой стороной
            bool lts = this.y + y < 0; // выход за границу верхней стороной
            bool lrs = this.x + this.w + x > Init.pbw; // выход за границу правой стороной
            bool lbs = this.y + this.h + y > Init.pbh; // выход за границу нижней стороной

            return !(lls || lts || lrs || lbs);
        }

        public override void move_to(int x, int y)
        {
            if (this.move_check(x, y))
            {
                this.x += x;
                this.y += y;
                this.drop_figure(this, true);
                this.draw();
            }
        }
    }
}
