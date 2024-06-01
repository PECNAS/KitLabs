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
    /// Логика взаимодействия для EventDataWindow.xaml
    /// </summary>
    public partial class EventDataWindow : Window
    {
        private Event _currentEvent = new Event();
        public EventDataWindow()
        {
            InitializeComponent();
            this.UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            DataContext = _currentEvent;
            DataGridTable.ItemsSource = trizbd_bdEntities1.GetContext().Events.ToList();
        }

        public void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var event4remove = DataGridTable.SelectedItem as Event;
            trizbd_bdEntities1.GetContext().Events.Remove(event4remove);
            trizbd_bdEntities1.GetContext().SaveChanges();

            UpdateDataGrid();
        }

        public void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new EventInsertWindow(DataGridTable.SelectedItem as Event);
            win.ShowDialog();
            this.UpdateDataGrid();
        }

        public void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var win = new EventInsertWindow();
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
