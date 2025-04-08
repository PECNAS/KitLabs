using System.Threading;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        private static int comparisons = 0;
        private static int permutations = 0;
        private static string time = "MM:SS:MS";
        public static string line = "";
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        public static void AddSortLine(string str)
        {
            line += str + "\r\n";
        }
        public void AddLine()
        {
            textBox2.Text += line;
            line = "";
        }
        public static void ReadInfo(int comp, int perm, string ti)
        {
            comparisons = comp;
            permutations = perm;
            time = ti;
        }

        public void FillLine(bool source = true)
        {
            if (source) this.textBox2.Text = "Исходный массив:\r\n";
            else this.textBox2.Text += "Результат сортировки: ";

            foreach (var i in Context.array)
                this.textBox2.Text += i + " ";
            this.textBox2.Text += "\r\n\r\n";
        }
        private void PrintInfo()
        {
            comparisionLabel.Text = comparisons.ToString();
            swapLabel.Text = permutations.ToString();
            timeLabel.Text = time.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void buttonGeneration_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            button1.Enabled = true;

            var newArr = new int[trackBar1.Value];

            for (int i = 0; i < newArr.Length; i++)
                newArr[i] = random.Next(0, 10000);

            Context.array = newArr;
            FillLine();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text != "" && Context.array != null)
            {
                button1.Enabled = false;
                FileOut.fileString = null;

                var mboxResult = MessageBox.Show("Подготовить файл для сохранения?", "Внимание", MessageBoxButtons.YesNo);
                var flag = mboxResult == DialogResult.Yes;

                Context context;
                if (radioButton1.Checked) context = new(new SimpleSort());
                else context = new(new ImprovedSort());


                context.SortArr(flag);
                AddLine();
                PrintInfo();
                FileOut.sorted = true;
                FillLine(false);


                if (flag) this.SaveAs_Click();
            } else MessageBox.Show("Ошибка! Сначала сгенерируйте массив или откройте его из файла");
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            string text;
            button1.Enabled = true;

            var ofd = new OpenFileDialog();
            ofd.Filter = "Text files(*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
                using (var reader = new StreamReader(ofd.FileName))
                    text = reader.ReadToEnd();
            else return;

            var stringArr = text.Split(' ');
            var intArr = new int[stringArr.Length];

            for (int i = 0; i < intArr.Length; i++)
                if (int.TryParse(stringArr[i], out intArr[i]) == false)
                {
                    MessageBox.Show("Ошибка");
                    return;
                }

            Context.array = intArr;
            FillLine();
        }

        private void SaveAs_Click(object sender=null, EventArgs e=null)
        {
            if (FileOut.fileString == null)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            var sfd = new SaveFileDialog();
            sfd.Filter = "Text files(*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK) FileOut.SaveFile(sfd.FileName);
        }

        private void AnalysButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (int.TryParse(textBox1.Text, out int value))
                {
                    if (value >= trackBar1.Minimum && value <= trackBar1.Maximum) trackBar1.Value = value;
                    else MessageBox.Show("Ошибка! Введено значение, выходящее за предел 1-40");
                }
                else MessageBox.Show("Ошибка! Неверный формат введенных данных для генерации!");
            }
        }
    }
}
