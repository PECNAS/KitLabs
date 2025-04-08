using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            var rand = new Random();
            int cols = rand.Next(1, 5);
            int rows = rand.Next(1, 5);

            double[,] matrix1 = new double[rows, cols];
            double[,] matrix2 = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix1[i, j] = Math.Round(rand.NextDouble() * 2 - 1, 2);
                    matrix2[i, j] = Math.Round(rand.NextDouble() * 2 - 1, 2);
                    textBox1.Text += $"{matrix1[i, j]}\t";
                    textBox2.Text += $"{matrix2[i, j]}\t";
                }
                textBox1.Text += "\r\n";
                textBox2.Text += "\r\n";
            }

            for (int row = 0; row < matrix1.GetUpperBound(0) + 1; row++)
            {
                for (int col = 0; col < matrix1.GetUpperBound(1) + 1; col++)
                {
                    textBox3.Text += $"{matrix1[row, col] + matrix2[row, col]}\t";
                }
                textBox3.Text += "\r\n";
            }
        }
    }
}
