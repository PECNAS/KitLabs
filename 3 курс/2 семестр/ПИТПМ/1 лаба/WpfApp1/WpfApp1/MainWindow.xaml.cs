using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<int> parse_input()
        {
            List<int> mas = new List<int>();
            string[] smas = this.InputTB.Text.Split(',');

            for (int i = 0; i < smas.Length; i++)
            {
                mas.Add(int.Parse(smas[i]));
            }

            this.InputTB.Text = "";

            return mas;
        }

        public void fill_output(List<int> mas)
        {
            OutputTB.Text = "";
            for (int i = 0; i < mas.Count; i++) {
                OutputTB.Text += mas[i].ToString();
                if (i != mas.Count -1)
                {
                    OutputTB.Text += ", ";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<int> mas = parse_input();
            SwapSort sorter = new SwapSort();
            mas = sorter.sort(mas);
            fill_output(mas);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<int> mas = parse_input();
            ShellSort sorter = new ShellSort();
            mas = sorter.sort(mas);
            fill_output(mas);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<int> mas = parse_input();
            ViborSort sorter = new ViborSort();
            mas = sorter.sort(mas);
            fill_output(mas);
        }
    }
}