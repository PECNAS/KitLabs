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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int rows))
            {
                if (int.TryParse(textBox2.Text, out int cols))
                {
                    if (!(rows <= 6 && cols <= 6)) {
                        MessageBox.Show("Пожалуйста, введите числа не более 6");
                    } else {
                        textBox3.Text = "";
                        textBox4.Text = "";

                        var rand = new Random();
                        double[,] matrix = new double[rows, cols];
                        double max_n = 0;

                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                matrix[i, j] = rand.Next(50);
                                textBox4.Text += $"{matrix[i, j]}\t";
                                if (matrix[i, j] > max_n) max_n = matrix[i, j];
                            }
                            textBox4.Text += "\r\n";
                        }

                        label4.Text = max_n.ToString();

                        for (int row = 0; row < matrix.GetUpperBound(0) + 1; row++)
                        {
                            for (int col = 0; col < matrix.GetUpperBound(1) + 1; col++)
                            {
                                matrix[row, col] = Math.Round(matrix[row, col] / max_n, 1);
                                textBox3.Text += $"{matrix[row, col]}\t";
                            }
                            textBox3.Text += "\r\n";
                        }
                    }
                } else {
                    MessageBox.Show("Введите количество столбцов в формате целого числа");
                }
            } else {
                MessageBox.Show("Введите количество строк в формате целого числа");
            }
        }
    }
}
