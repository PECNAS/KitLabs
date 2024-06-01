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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked) groupBox1.BackColor = Color.Green;
            else groupBox1.BackColor = Color.Red;

            if (radioButton5.Checked) groupBox2.BackColor = Color.Green;
            else groupBox2.BackColor = Color.Red;

            if (radioButton8.Checked) groupBox3.BackColor = Color.Green;
            else groupBox3.BackColor = Color.Red;

            if (radioButton10.Checked) groupBox4.BackColor = Color.Green;
            else groupBox4.BackColor = Color.Red;

            if (radioButton15.Checked) groupBox5.BackColor = Color.Green;
            else groupBox5.BackColor = Color.Red;
        }
    }
}
