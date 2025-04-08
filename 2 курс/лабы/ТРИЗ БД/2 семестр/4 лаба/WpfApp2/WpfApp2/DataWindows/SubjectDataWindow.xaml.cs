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
    /// Логика взаимодействия для SubjectDataWindow.xaml
    /// </summary>
    public partial class SubjectDataWindow : Window
    {
        private Subject _currentSubject = new Subject();
        public SubjectDataWindow()
        {
            InitializeComponent();
            this.UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            DataContext = _currentSubject;
            DataGridTable.ItemsSource = trizbd_bdEntities1.GetContext().Subjects.ToList();
        }

        public void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var subject4remove = DataGridTable.SelectedItem as Subject;
            trizbd_bdEntities1.GetContext().Subjects.Remove(subject4remove);
            trizbd_bdEntities1.GetContext().SaveChanges();

            UpdateDataGrid();
        }

        public void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new SubjectInsertWindow(DataGridTable.SelectedItem as Subject);
            win.ShowDialog();
            this.UpdateDataGrid();
        }

        public void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var win = new SubjectInsertWindow();
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
