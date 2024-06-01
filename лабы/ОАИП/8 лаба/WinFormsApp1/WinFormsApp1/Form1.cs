using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int w; // ширина фигуры
        private int h; // высота фигуры
        private int r; // радиус окружности
        private int a; // длина стороны
        private int n; // количество углов многоугольника
        private int x_pos; // положение фигуры при создании по x
        private int y_pos; // положение фигуры при создании по y

        public Form1()
        {
            InitializeComponent();
            Init.bitmap = new Bitmap(this.pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height); ;
            Init.pen = new Pen(Color.Black, 1);
            Init.pb = this.pictureBox1;
            Init.pbw = Init.pb.Width;
            Init.pbh = Init.pb.Height;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool get_data(
            bool rect = false,
            bool sq = false,
            bool el = false,
            bool circ = false,
            bool pol = false,
            bool tri = false,
            bool rocket = false
            )
        {
            bool state = true;

            if (rect || sq || rocket || el)
            {
                if (int.TryParse(this.textBox1.Text, out int w) && w > 0) this.w = w;
                else
                {
                    MessageBox.Show("¬веден неверный формат данных в поле ширины фигуры");
                    state = false;
                }
            }

            if (rect || el || rocket)
            {
                if (int.TryParse(this.textBox2.Text, out int h) && h > 0) this.h = h;
                else
                {
                    MessageBox.Show("¬веден неверный формат данных в поле высоты фигуры");
                    state = false;
                }
            }

            if (circ)
            {
                if (int.TryParse(this.textBox3.Text, out int r)) this.r = r;
                else
                {
                    MessageBox.Show("¬веден неверный формат данных в поле радиуса");
                    state = false;
                }
            }

            if (tri)
            {
                if (int.TryParse(this.textBox4.Text, out int a)) this.a = a;
                else
                {
                    MessageBox.Show("¬веден неверный формат данных в поле длины стороны");
                    state = false;
                }
            }

            if (pol)
            {
                if (int.TryParse(this.textBox5.Text, out int n)) this.n = n;
                else
                {
                    MessageBox.Show("¬веден неверный формат данных в поле количества углов");
                    state = false;
                }
            }

            if (int.TryParse(this.textBox8.Text, out int x_pos))
            {
                if (0 <= x_pos && x_pos + this.w <= Init.pbw) this.x_pos = x_pos;
                else
                {
                    MessageBox.Show("”казанное значение x выходит за границы пол€");
                    state = false;
                }
            }
            else this.x_pos = 0;

            if (int.TryParse(this.textBox7.Text, out int y_pos))
            {
                if (0 <= y_pos && y_pos + this.h <= Init.pbw) this.y_pos = y_pos;
                else
                {
                    MessageBox.Show("”казанное значение y выходит за границы пол€");
                    state = false;
                }
            }
            else this.y_pos = 0;

            if (state) return true;
            else return false;
        }

        private void clear_boxes()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.clear_boxes();
        }

        private void button1_Click(object sender, EventArgs e) // пр€моугольник
        {
            if (this.get_data(rect: true))
            {
                Rectangle rectangle = new Rectangle(this.x_pos, this.y_pos, this.w, this.h);
                if (rectangle.move_check(0, 0))
                {
                    rectangle.draw();
                    this.clear_boxes();
                    ShapeContainer.AddFigure(rectangle);
                    this.comboBox1.Items.Add(rectangle.get_name());
                }
                else MessageBox.Show("Ќеверные размеры фигуры, выход€щие за границы пол€");

            }
        }


        private void button2_Click(object sender, EventArgs e) // круг
        {
            if (this.get_data(circ: true))
            {
                Circle circle = new Circle(this.x_pos, this.y_pos, this.r);
                if (circle.move_check(0, 0))
                {
                    circle.draw();
                    clear_boxes();
                    ShapeContainer.AddFigure(circle);
                    this.comboBox1.Items.Add(circle.get_name());
                }
                else MessageBox.Show("Ќеверные размеры фигуры, выход€щие за границы пол€");

            }
        }

        private void button3_Click(object sender, EventArgs e) // треугольник
        {
            if (this.get_data(tri: true))
            {
                PointF[] points = new PointF[3];
                points[0] = new PointF(this.x_pos + this.a / 2, this.y_pos);
                points[1] = new PointF(this.x_pos + this.a, this.y_pos + this.a);
                points[2] = new PointF(this.x_pos, this.y_pos + this.a);

                Triangle triangle = new Triangle(points);
                if (triangle.move_check(0, 0))
                {
                    triangle.draw();
                    clear_boxes();

                    ShapeContainer.AddFigure(triangle);
                    this.comboBox1.Items.Add(triangle.get_name());
                }
                else MessageBox.Show("Ќеверные размеры фигуры, выход€щие за границы пол€");
            }
        }

        private void button4_Click(object sender, EventArgs e) // многоугольник
        {
            if (this.get_data(pol: true))
            {
                clear_boxes();
                Form2 frm = new Form2(this.n, this);
                frm.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e) // ракета
        {
            if (this.get_data(rocket: true))
            {
                Rocket rocket = new Rocket(this.x_pos, this.y_pos, this.w, this.h);
                if (rocket.move_check(0, 0))
                {
                    clear_boxes();
                    rocket.draw();
                    ShapeContainer.AddFigure(rocket);
                    this.comboBox1.Items.Add(rocket.get_name());
                }
                else MessageBox.Show("Ќеверные размеры фигуры, выход€щие за рамки экрана");

            }
        }

        private void button10_Click(object sender, EventArgs e) // квадрат
        {
            if (this.get_data(sq: true))
            {
                Square sq = new Square(this.x_pos, this.y_pos, this.w);

                if (sq.move_check(0, 0))
                {
                    clear_boxes();
                    sq.draw();
                    ShapeContainer.AddFigure(sq);
                    this.comboBox1.Items.Add(sq.get_name());
                }
                else MessageBox.Show("Ќеверные размеры фигуры, выход€щие за границы пол€");

            }
        }

        private void button6_Click(object sender, EventArgs e) // эллипс
        {
            if (this.get_data(el: true))
            {
                Ellipse el = new Ellipse(this.x_pos, this.y_pos, this.w, this.h);
                if (el.move_check(0, 0))
                {
                    this.clear_boxes();
                    el.draw();

                    ShapeContainer.AddFigure(el);
                    this.comboBox1.Items.Add(el.get_name());
                }
                else MessageBox.Show("Ќеверные размеры фигуры, выход€щие за границы пол€");
            }
        }

        private void left_btn_Click(object sender, EventArgs e)
        {
            string figure_name = this.comboBox1.Text;
            for (int i = 0; i < ShapeContainer.length; i++)
            {
                if (ShapeContainer.figureList[i].get_name() == figure_name)
                {
                    Figure figure = ShapeContainer.figureList[i];
                    figure.move_to(-10, 0);

                    break;
                }
            }
        }

        private void up_btn_Click(object sender, EventArgs e)
        {
            string figure_name = this.comboBox1.Text;
            for (int i = 0; i < ShapeContainer.length; i++)
            {
                if (ShapeContainer.figureList[i].get_name() == figure_name)
                {
                    Figure figure = ShapeContainer.figureList[i];
                    figure.move_to(0, -10);

                    break;
                }
            }
        }

        private void right_btn_Click(object sender, EventArgs e)
        {
            string figure_name = this.comboBox1.Text;
            for (int i = 0; i < ShapeContainer.length; i++)
            {
                if (ShapeContainer.figureList[i].get_name() == figure_name)
                {
                    Figure figure = ShapeContainer.figureList[i];
                    figure.move_to(10, 0);

                    break;
                }
            }
        }

        private void down_btn_Click(object sender, EventArgs e)
        {
            string figure_name = this.comboBox1.Text;
            for (int i = 0; i < ShapeContainer.length; i++)
            {
                if (ShapeContainer.figureList[i].get_name() == figure_name)
                {
                    Figure figure = ShapeContainer.figureList[i];
                    figure.move_to(0, 10);

                    break;
                }
            }

        }

        private void dropFigure_Click(object sender, EventArgs e)
        {
            string figure_name = this.comboBox1.Text;
            for (int i = 0; i < ShapeContainer.length; i++)
            {
                if (ShapeContainer.figureList[i].get_name() == figure_name)
                {
                    this.comboBox1.Items.Remove(figure_name);
                    Figure figure = ShapeContainer.figureList[i];
                    figure.drop_figure(figure);

                    break;
                }
            }
        }
    }
}


