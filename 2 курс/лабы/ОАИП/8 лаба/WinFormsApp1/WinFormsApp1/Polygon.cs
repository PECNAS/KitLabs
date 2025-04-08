using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsApp1
{
    public class Polygon : Figure
    {
        public int count;
        public int a;
        public PointF[] points;

        public Polygon(PointF[] points = null)
        {
            this.points = points;
            if (points == null) this.count = 3;
            else this.count = points.Length;
        }

        public override void draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, this.points);
            Init.pb.Image = Init.bitmap;
        }

        public override bool move_check(int x, int y)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (!(points[i].X + x <= Init.pbw && points[i].Y + y <= Init.pbh && points[i].X + x >= 0 && points[i].Y + y >= 0))
                {
                    return false; 
                }
            }

            return true;

        }

        public override void move_to(int x, int y)
        {
            if (this.move_check(x, y))
            {
                for (int i = 0; i < this.count; i++)
                {
                    this.points[i].X += x;
                    this.points[i].Y += y;
                }

                this.drop_figure(this, true);
                this.draw();
            }
        }
    }
}
