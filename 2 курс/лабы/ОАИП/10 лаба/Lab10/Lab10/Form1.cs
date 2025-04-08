using System.Threading;

namespace Lab10
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
            labelTrackBar.Text = trackBar1.Value.ToString();
            radioButtonSimple.Checked = true;
        }
        public static void AddSortLine(string str)
        {
            line += str + '\n';
        }
        public void AddLine()
        {
            richTextBox.Text += line;
            line = "";
        }
        public static void ReadInfo(int comp, int perm, string ti)
        {
            comparisons = comp;
            permutations = perm;
            time = ti;
        }

        public void FillLine()
        {
            richTextBox.Text = "»ÒıÓ‰Ì˚È Ï‡ÒÒË‚:\n";
            foreach (var i in Context.array)
                richTextBox.Text += i + " ";
            richTextBox.Text += "\n\n";
        }
        private void PrintInfo()
        {
            labelComp.Text = comparisons.ToString();
            labelperm.Text = permutations.ToString();
            labeltime.Text = time.ToString();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelTrackBar.Text = trackBar1.Value.ToString();
        }

        private void buttonGeneration_Click(object sender, EventArgs e)
        {
            var newArr = new int[trackBar1.Value];

            for (int i = 0; i < newArr.Length; i++)
                newArr[i] = random.Next(0, 100);

            Context.array = newArr;
            FillLine();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (richTextBox.Text != "")
            {
                FileOut.fileString = null;
                var mboxResult = MessageBox.Show("œÓ‰„ÓÚÓ‚ËÚ¸ Ù‡ÈÎ ‰Îˇ ÒÓı‡ÌÂÌËˇ?", "¬ÌËÏ‡ÌËÂ", MessageBoxButtons.YesNo);

                var flag = mboxResult == DialogResult.Yes;

                Context context;
                if (radioButtonImproved.Checked)
                    context = new(new ImprovedSort());
                else
                    context = new(new SimpleSort());


                context.SortArr(flag);
                AddLine();
                PrintInfo();
                FileOut.sorted = true;
                PrintInfo();
            }
        }

        private void ÓÚÍ˚Ú¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text;

            var ofd = new OpenFileDialog();
            ofd.Filter = "Text files(*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
                using (var reader = new StreamReader(ofd.FileName))
                    text = reader.ReadToEnd();
            else
                return;

            var stringArr = text.Split(' ');
            var intArr = new int[stringArr.Length];

            for (int i = 0; i < intArr.Length; i++)
                if(int.TryParse(stringArr[i], out intArr[i])==false)
                {
                    MessageBox.Show("Œ¯Ë·Í‡");
                    return;
                }

            Context.array = intArr;

            FillLine();
        }

        private void ÒÓı‡ÌËÚ¸ ‡ÍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FileOut.fileString == null)
            {
                MessageBox.Show("Œ¯Ë·Í‡");
                return;
            }
            var sfd = new SaveFileDialog();
            sfd.Filter = "Text files(*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
                FileOut.SaveFile(sfd.FileName);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }
    }
}
