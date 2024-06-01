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
using WpfApp2.InsertWindows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для GroupsDataWindow.xaml
    /// </summary>
    public partial class GroupsDataWindow : Window
    {
        private Groups _currentGroup = new Groups();
        public GroupsDataWindow()
        {
            InitializeComponent();
            this.UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            DataContext = _currentGroup;
            DataGridTable.ItemsSource = trizbd_bdEntities1.GetContext().Group.ToList();
        }

        public void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var group4remove = DataGridTable.SelectedItem as Groups;
            trizbd_bdEntities1.GetContext().Group.Remove(group4remove);
            trizbd_bdEntities1.GetContext().SaveChanges();

            UpdateDataGrid();
        }

        public void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new GroupInsertWindow(DataGridTable.SelectedItem as Groups);
            win.ShowDialog();
            this.UpdateDataGrid();
        }

        public void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var win = new GroupInsertWindow();
            win.ShowDialog();
            this.UpdateDataGrid();
        }

        public void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
