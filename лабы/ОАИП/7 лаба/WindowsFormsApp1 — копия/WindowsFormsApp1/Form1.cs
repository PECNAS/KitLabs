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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            MessageBox.Show("Перед вами сейчас появится тест, состоящий из пяти вопросов. За правильный ответ на вопрос он выделится зеленым цветом. При неверном ответе - красным");
            frm.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            MessageBox.Show("В данной программе на ввод подается число. После нажатия на кнопку программа вычисляет количество чисел-палиндромов меньше введенного числа");
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            MessageBox.Show("В данной программе вам необходимо ввести два число для генерирования матрицы введенной размерности, после чего программа найдет максимальный элемент в матрице и поделит каждое число исходной на этот максимальный элемент");
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            MessageBox.Show("При нажатии на кнопку 'Сгенерировать', программа сгенерирует две матрицы, после чего сложит их и выведет результат");
            frm.ShowDialog();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            MessageBox.Show("В данной програме реализован класс, который позволяет управлять вашим банковским счетом. С помощью этой программы вы сможете создавать счет, менять владельца, переводить сумму в доллары/евро, снимкать и вносить деньги");
            frm.ShowDialog();
        }

    }
}
