using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Rocket:Figure
    {
        private Triangle nose; // нос
        private Polygon fire; // огонек
        private Polygon left; // левое крыло
        private Polygon right; // правое крыло
        private Rectangle body; // тело
        private Ellipse c1; // иллюминатор 1
        private Ellipse c2; // иллюминатор 2
        private Ellipse c3; // иллюминатор 3

        private PointF[] pointsl;
        private PointF[] pointsr;
        private PointF[] pointst;
        private PointF[] pointsf;



        public Rocket(int x = 100, int y = 100, int w = 50, int h = 150)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            this.pointst = new PointF[3];
            this.pointst[0] = new PointF((float)(x + w * 0.25), (float)(y + h * 0.3));
            this.pointst[1] = new PointF((float)(x + w * 0.5), y);
            this.pointst[2] = new PointF((float)(x + w * 0.75), (float)(y + h * 0.3));
            this.nose = new Triangle(pointst);

            this.body = new Rectangle((int)(x + w * 0.25), (int)(h * 0.3), w / 2, (int)(h * 0.6));

            this.pointsl = new PointF[3];
            this.pointsl[0] = new PointF((float)(x + w * 0.25), (float)(y + h * 0.6));
            this.pointsl[1] = new PointF((float)(x + w * 0.25), (float)(y + h * 0.9));
            this.pointsl[2] = new PointF(x, (float)(y + h * 0.9));
            this.left = new Polygon(this.pointsl);

            this.pointsr = new PointF[3];
            this.pointsr[0] = new PointF((float)(x + w * 0.75), (float)(y + h * 0.6));
            this.pointsr[1] = new PointF((float)(x + w * 0.75), (float)(y + h * 0.9));
            this.pointsr[2] = new PointF((float)(x + w), (float)(y + h * 0.9));
            this.right = new Polygon(this.pointsr);

            this.c1 = new Ellipse((int)(x + w * 0.33), (int)(y + h * 0.4), w / 3, (int)(h * 0.1));
            this.c2 = new Ellipse((int)(x + w * 0.33), (int)(y + h * 0.55), w / 3, (int)(h * 0.1));
            this.c3 = new Ellipse((int)(x + w * 0.33), (int)(y + h * 0.7), w / 3, (int)(h * 0.1));

            this.pointsf = new PointF[9];
            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0) this.pointsf[i] = new PointF((float)(x + w * 0.25 + i * w / 16), (float)(y + h * 0.9));
                else this.pointsf[i] = new PointF((float)(x + w * 0.25 + i * w / 16), y + h);
            }
            this.fire = new Polygon(pointsf);

        }
        public override void draw()
        {
            this.nose.draw();
            this.body.draw();
            this.left.draw();
            this.right.draw();
            this.c1.draw();
            this.c2.draw();
            this.c3.draw();
            this.fire.draw();
        }

        public override void move_to(int x, int y)
        {
            if (this.move_check(x, y))
            {
                this.nose.move_to(x, y);
                this.body.move_to(x, y);
                this.left.move_to(x, y);
                this.right.move_to(x, y);
                this.c1.move_to(x, y);
                this.c2.move_to(x, y);
                this.c3.move_to(x, y);
                this.fire.move_to(x, y);

                this.x += x;
                this.y += y;
            }

        }

        public override bool move_check(int x, int y)
        {
            if (this.x + x < 0 || this.x + w + x > Init.pbw) return false;
            else if (this.y + h > Init.pbh || this.y + y < 0) return false;
            else return true;
        }
    }
}
