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
    /// Логика взаимодействия для Health_Card.xaml
    /// </summary>
    public partial class Health_Card : Window
    {
        public Health_Card()
        {
            InitializeComponent();
        }
        private void ButtonList_Click_1(object sender, RoutedEventArgs e)
        {
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Health_Card.ToList();
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Health_Card.OrderBy(x =>
           x.Record_ID).ToList();
        }

        private void ButtonAdd_Click_1(object sender, RoutedEventArgs e)
        {
            Health_CardAddInfo Health_CardAddInfo = new Health_CardAddInfo();
            Health_CardAddInfo.Show();
            this.Hide();
        }

        private void ButtonDeleteGrid_Click(object sender, RoutedEventArgs e)
        {
            var studentRemoving = DataGridStudent.SelectedItems.Cast<Health_Card>().ToList();
            if (MessageBox.Show($"Подтвердить удаление?", "!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) !=
           MessageBoxResult.Yes) return;

            Statement_curatorEntities.GetContext().Health_Card.RemoveRange(studentRemoving);
            Statement_curatorEntities.GetContext().SaveChanges();
            MessageBox.Show("Ура! Удалилось!");
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Health_Card.OrderBy(x =>
           x.Record_ID).ToList();


        }

        private void ButtonEditGrid_Click(object sender, RoutedEventArgs e)
        {
            var item = (Health_Card)DataGridStudent.SelectedItem;
            new Health_CardEditInfo(item).Show();
            Close();
        }

        private void ButtonTables_Click_1(object sender, RoutedEventArgs e)
        {
            WindowTables windowTables = new WindowTables();
            windowTables.Show();
            this.Hide();
        }
    }
}
