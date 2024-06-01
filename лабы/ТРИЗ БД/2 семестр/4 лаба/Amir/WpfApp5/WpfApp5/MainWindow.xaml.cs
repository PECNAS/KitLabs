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

namespace WpfApp5
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
        private void ButtonList_Click(object sender, RoutedEventArgs e)
        {
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Student.ToList();
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Student.OrderBy(x =>
           x.Student_ID).ToList();
        }
        private void ButtonDeleteGrid_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonEditGrid_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowAdd = new WindowAdd();
            windowAdd.Show();
            this.Hide();
        }

        private void ButtonTables_Click(object sender, RoutedEventArgs e)
        {

            WindowTables windowTables = new WindowTables();
            windowTables.Show();
            this.Hide();
        }
    }
}
