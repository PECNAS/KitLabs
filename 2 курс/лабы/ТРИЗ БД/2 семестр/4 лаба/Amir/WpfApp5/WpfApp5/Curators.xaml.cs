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
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Curators.xaml
    /// </summary>
    public partial class Curators : Window
    {
        public Curators()
        {
            InitializeComponent();
        }
        private void ButtonList_Click_1(object sender, RoutedEventArgs e)
        {
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Curator.ToList();
        }

        private void ButtonAdd_Click_1(object sender, RoutedEventArgs e)
        {
            CuratorsAddInfo curatorsAddInfo = new CuratorsAddInfo();
            curatorsAddInfo.Show();
            this.Hide();
        }

        private void ButtonTables_Click_1(object sender, RoutedEventArgs e)
        {
            WindowTables windowTables = new WindowTables();
            windowTables.Show();
            this.Hide();
        }
        private void ButtonDeleteGrid_Click(object sender, RoutedEventArgs e)
        {
            var curatorRemoving = DataGridStudent.SelectedItems.Cast<Curator>().ToList();
            if (MessageBox.Show($"Подтвердить удаление?", "!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) !=
           MessageBoxResult.Yes) return;

            Statement_curatorEntities.GetContext().Curator.RemoveRange(curatorRemoving);
            Statement_curatorEntities.GetContext().SaveChanges();
            MessageBox.Show("Ура! Удалилось!");
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Curator.OrderBy(x =>
           x.Curator_ID).ToList();
        }
        private void ButtonEditGrid_Click(object sender, RoutedEventArgs e)
        {
            var item = (Curator)DataGridStudent.SelectedItem;
            new CuratorsEditInfo(item).Show();
            Close();
        }
    }
}
