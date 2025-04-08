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
    /// Логика взаимодействия для InstructorDataWindow.xaml
    /// </summary>
    public partial class InstructorDataWindow : Window
    {
        private Instructor _currentInstructor = new Instructor();
        public InstructorDataWindow()
        {
            InitializeComponent();
            this.UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            DataContext = _currentInstructor;
            DataGridTable.ItemsSource = trizbd_bdEntities1.GetContext().Instructors.ToList();
        }

        public void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var instructor4remove = DataGridTable.SelectedItem as Instructor;
            trizbd_bdEntities1.GetContext().Instructors.Remove(instructor4remove);
            trizbd_bdEntities1.GetContext().SaveChanges();

            UpdateDataGrid();
        }

        public void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new InstructorInsertWindow(DataGridTable.SelectedItem as Instructor);
            win.ShowDialog();
            this.UpdateDataGrid();
        }

        public void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var win = new InstructorInsertWindow();
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
