using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для WindowTables.xaml
    /// </summary>
    public partial class WindowTables : Window
    {
        public WindowTables()
        {
            InitializeComponent();
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Curators curator = new Curators();
            curator.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Parent parent = new Parent();
            parent.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Summary_Ledger summary_ledger = new Summary_Ledger();
            summary_ledger.Show();
            this.Hide();

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Health_Card health_card = new Health_Card();
            health_card.Show();
            this.Hide();
        }
    }
}
