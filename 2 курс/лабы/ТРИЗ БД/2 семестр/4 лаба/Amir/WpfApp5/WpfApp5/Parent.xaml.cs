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
    /// Логика взаимодействия для Parent.xaml
    /// </summary>
    public partial class Parent : Window
    {
        public Parent()
        {
            InitializeComponent();
        }
        private void ButtonList_Click_1(object sender, RoutedEventArgs e)
        {
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Parents.ToList();
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Parents.OrderBy(x =>
           x.Parent_ID).ToList();
        }

        private void ButtonAdd_Click_1(object sender, RoutedEventArgs e)
        {
            ParrentsAddInfo storeAddInfo = new ParrentsAddInfo();
            storeAddInfo.Show();
            this.Hide();
        }

        private void ButtonTables_Click(object sender, RoutedEventArgs e)
        {
            WindowTables windowTables = new WindowTables();
            windowTables.Show();
            this.Hide();
        }
        private void ButtonDeleteGrid_Click(object sender, RoutedEventArgs e)
        {
            var studentRemoving = DataGridStudent.SelectedItems.Cast<Parents>().ToList();
            if (MessageBox.Show($"Подтвердить удаление?", "!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) !=
           MessageBoxResult.Yes) return;

            Statement_curatorEntities.GetContext().Parents.RemoveRange(studentRemoving);
            Statement_curatorEntities.GetContext().SaveChanges();
            MessageBox.Show("Ура! Удалилось!");
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Parents.OrderBy(x =>
           x.Parent_ID).ToList();


        }
        private void ButtonEditGrid_Click(object sender, RoutedEventArgs e)
        {
            var item = (Parents)DataGridStudent.SelectedItem;
            new ParentsEditInfo(item).Show();
            Close();
        }
    }
}
