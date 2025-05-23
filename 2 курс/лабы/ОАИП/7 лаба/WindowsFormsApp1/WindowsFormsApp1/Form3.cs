﻿using System;
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
            if (int.TryParse(textBox1.Text, out int N))
            {
                listBox1.Items.Clear();
                if (N < 11) listBox1.Items.Add("Палиндромов, меньше числа N не найдено");
                else
                {
                    for (int i = 11; i <= N; i++)
                    {
                        string num = Convert.ToString(i);
                        var reversed_num = new string(num.Reverse().ToArray());
                        if (reversed_num.Equals(num))
                        {
                            listBox1.Items.Add(num);
                        }
                    }
                }

            } else MessageBox.Show("Ошибка вводных данных! На вход я могу принимать только целые числа");
        }
    }
}
