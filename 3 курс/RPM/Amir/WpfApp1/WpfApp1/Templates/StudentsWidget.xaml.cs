using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfApp1.Base.Entities;
using WpfApp1.Base;
using WpfApp1.Templates.DetailsWindows;

namespace WpfApp1.Templates
{
    /// <summary>
    /// Логика взаимодействия для StudentsWidget.xaml
    /// </summary>
    public partial class StudentsWidget : UserControl
    {
        MainWindow root;
        public StudentsWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new SchoolContext())
            {
                this.StudentsList.ItemsSource =
                    context.Students.Include(s => s.Instructor).ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new StudentDetail();
            detailWindow.ShowDialog();

            using (var context = new SchoolContext())
            {
                this.StudentsList.ItemsSource =
                    context.Students.Include(s => s.Instructor).ToList();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Student student = this.StudentsList.SelectedItem as Student;
            if (student != null)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить {student.Name}?",
                    "Delete object",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    using (var context = new SchoolContext())
                    {
                        context.Students.Attach(student);
                        context.Entry(student).State = EntityState.Deleted;
                        context.SaveChanges();

                        this.StudentsList.ItemsSource =
                            context.Students.Include(s => s.Instructor).ToList();
                    }
                }
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Student student = this.StudentsList.SelectedItem as Student;
            if (student != null)
            {
                var detailWindow = new StudentDetail(student);
                detailWindow.ShowDialog();

                using (var context = new SchoolContext())
                {
                    this.StudentsList.ItemsSource =
                        context.Students.Include(s => s.Instructor).ToList();
                }
            }

        }
    }
}
