using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int max = 0;
            int min = 0;
            int sr = 0;
            foreach (var item in text.Split('\n'))
            {
                if (!(int.TryParse(item, out int N)))
                {
                    MessageBox.Show("Ошибка вводных данных! На вход я могу принимать только целые числа");
                    break;
                } else
                {
                    if (N > max) max = N;
                    else if (N < min) min = N;
                    sr += N;
                }
            }

            this.label4.Text = $"Максимальный рост: {max}";
            this.label3.Text = $"Минимальный рост: {min}";
            this.label4.Text = $"Средний рост: {sr / text.Split('\n').Length}";
        }
    }
}
