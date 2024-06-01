using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private PointF[] points;
        private int active_angle = 0;
        private int n_angles;
        public Form1 form1;

        public Form2(int n_angles, Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            this.n_angles = n_angles;
            this.points = new PointF[n_angles];
            this.progressBar1.Maximum = n_angles;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(this.textBox1.Text, out int x);
            int.TryParse(this.textBox2.Text, out int y);

            if (x > 0 && x <= Init.pbw && y > 0 && y <= Init.pbh)
            {
                textBox1.Text = "";
                textBox2.Text = "";

                this.listBox1.Items.Add($"{x}, {y}");
                this.points[this.active_angle] = new PointF(x, y);
                this.progressBar1.Value += 1;
                this.active_angle += 1;
            } else {
                MessageBox.Show("Неверный координаты точки!");
            }

            if (this.active_angle == this.n_angles)
            {
                MessageBox.Show("Многоугольник успешно создан!");

                Polygon pol = new Polygon(this.points);
                pol.draw();

                ShapeContainer.AddFigure(pol);
                this.form1.comboBox1.Items.Add(pol.get_name());

                this.Close();
            }
        }
    }
}
