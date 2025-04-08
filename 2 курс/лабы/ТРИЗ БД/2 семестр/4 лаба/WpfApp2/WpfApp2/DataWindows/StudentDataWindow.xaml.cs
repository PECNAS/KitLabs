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
    /// Логика взаимодействия для StudentDataWindow.xaml
    /// </summary>
    public partial class StudentDataWindow : Window
    {
        private Student _currentStudent = new Student();
        public StudentDataWindow()
        {
            InitializeComponent();
            this.UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            DataContext = _currentStudent;
            DataGridTable.ItemsSource = trizbd_bdEntities1.GetContext().Students.ToList();
        }

        public void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var student4remove = DataGridTable.SelectedItem as Student;
            trizbd_bdEntities1.GetContext().Students.Remove(student4remove);
            trizbd_bdEntities1.GetContext().SaveChanges();

            UpdateDataGrid();
        }

        public void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new StudentInsertWindow(DataGridTable.SelectedItem as Student);
            win.ShowDialog();
            this.UpdateDataGrid();
        }

        public void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var win = new StudentInsertWindow();
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
