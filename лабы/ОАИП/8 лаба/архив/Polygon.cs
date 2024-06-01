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
        public PointF[] points;

        public Polygon(int x = 0, int y = 0, int w = 20, int count = 3)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.count = count;
            this.points = new PointF[this.count];

        }

        public override void draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, this.points);

            Init.pb.Image = Init.bitmap;
            MessageBox.Show(this.count.ToString());
        }

        public override bool move_check(int x, int y)
        {
            return true;
        }

        public override void move_to(int x, int y)
        {
            if (this.move_check(x, y))
            {
                this.x += x;
                this.y += y;
                this.drop_figure(this);
                this.draw();
            }
        }
    }
}
