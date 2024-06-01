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
    /// Логика взаимодействия для TimetableDataWindow.xaml
    /// </summary>
    public partial class TimetableDataWindow : Window
    {
        private Timetable _currentTB = new Timetable();
        public TimetableDataWindow()
        {
            InitializeComponent();
            this.UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            DataContext = _currentTB;
            DataGridTable.ItemsSource = trizbd_bdEntities1.GetContext().Timetables.ToList();
        }

        public void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var tb4remove = DataGridTable.SelectedItem as Timetable;
            trizbd_bdEntities1.GetContext().Timetables.Remove(tb4remove);
            trizbd_bdEntities1.GetContext().SaveChanges();

            UpdateDataGrid();
        }

        public void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new TimetableInsertWindow(DataGridTable.SelectedItem as Timetable);
            win.ShowDialog();
            this.UpdateDataGrid();
        }

        public void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var win = new TimetableInsertWindow();
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
