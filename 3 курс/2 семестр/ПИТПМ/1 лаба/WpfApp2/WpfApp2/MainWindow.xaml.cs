using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
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
            for (int i = 0; i < mas.Count; i++)
            {
                OutputTB.Text += mas[i].ToString();
                if (i != mas.Count - 1)
                {
                    OutputTB.Text += ", ";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<int> source_mas = parse_input();
            SwapSort sorter = new SwapSort();
            List<int> mas = sorter.sort(source_mas);
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
