using static System.Windows.Forms.AxHost;
using System;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init.bitmap = new Bitmap(this.pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height); ;
            Init.pen = new Pen(Color.Black, 1);
            Init.pb = this.pictureBox1;
            Init.pbw = Init.pb.Width;
            Init.pbh = Init.pb.Height;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string seq = this.textBox1.Text;
                RPN.calculate_rpn(seq, this);
                this.textBox1.Text = "";
            }
        }
    }
}
