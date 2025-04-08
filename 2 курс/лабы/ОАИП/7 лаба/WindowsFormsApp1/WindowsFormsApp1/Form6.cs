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
    public partial class Form6 : Form
    {
        Accaunt acc;

        public Form6()
        {
            InitializeComponent();
            button6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button6.Enabled = true;

            this.acc = new Accaunt(textBox1.Text);

            label10.Text = acc.get_owner();
            label3.Text = acc.get_acc_num().ToString();
            label5.Text = acc.get_percent().ToString();
            label7.Text = acc.get_summ().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int summ))
            {
                bool res = this.acc.put_summ(summ);
                if (!res) MessageBox.Show("Ошибка! Введено отрицательное число");
                else label7.Text = this.acc.get_summ().ToString();
            } else {
                MessageBox.Show("Ошибка! Неверный формат входных данных");
            }

            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int summ))
            {
                bool res = this.acc.take_summ(summ);
                if (!res) MessageBox.Show("Ошибка! Проверьте, что вы ввели");
                else label7.Text = this.acc.get_summ().ToString();
            }
            else
            {
                MessageBox.Show("Ошибка! Неверный формат входных данных");
            }

            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label7.Text = this.acc.to_dollars().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label7.Text = this.acc.to_euros().ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.acc.set_owner(textBox4.Text);
            textBox4.Text = "";
            label10.Text = this.acc.get_owner();
        }
    }
    class Accaunt
    {
        private string owner;
        private double summ;
        private long acc_num;
        private int percent;

        public Accaunt(string owner)
        {
            this.owner = owner;
            var rand = new Random();
            this.summ = 0;
            this.acc_num = Convert.ToInt64($"408178109991{rand.Next(1000000, 9999999)}");
            this.percent = rand.Next(5, 15);

        }

        public long get_acc_num()
        {
            return this.acc_num;
        }

        public int get_percent()
        {
            return this.percent;
        }
        public void set_owner(string owner)
        {
            this.owner = owner;
        }

        public string get_owner()
        {
            return this.owner;
        }
        public bool take_summ(double delta)
        {
            if (delta <= this.summ && delta > 0)
            {
                this.summ -= delta;
                return true;
            }
            return false;
        }
        public bool put_summ(double delta)
        {
            if (delta >= 0)
            {
                this.summ += delta;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void add_percent()
        {
            this.summ += (this.summ / 100) * (this.percent / 12);
        }
        public double get_summ()
        {
            return this.summ;
        }
        public double to_dollars()
        {
            return this.summ / 92;
        }
        public double to_euros()
        {
            return this.summ / 99;
        }
    }
}
