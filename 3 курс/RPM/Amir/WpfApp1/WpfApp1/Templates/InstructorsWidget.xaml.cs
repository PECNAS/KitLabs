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
    /// Логика взаимодействия для InstructorsWidget.xaml
    /// </summary>
    public partial class InstructorsWidget : UserControl
    {
        MainWindow root;
        public InstructorsWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new SchoolContext())
            {
                this.InstructorsList.ItemsSource =
                    context.Instructors.Include(c => c.Car).ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new InstructorDetail();
            detailWindow.ShowDialog();

            using (var context = new SchoolContext())
            {
                this.InstructorsList.ItemsSource =
                    context.Instructors.Include(c => c.Car).ToList();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Instructor instructor = this.InstructorsList.SelectedItem as Instructor;
            if (instructor != null)
            {
                if (instructor.Students.Count > 0)
                {
                    MessageBox.Show("Невозможно удалить инструктора, так как к нему прикреплены ученики");
                    return;
                }

                if (MessageBox.Show($"Вы уверены, что хотите удалить {instructor.Name}?",
                    "Delete object",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    using (var context = new SchoolContext())
                    {
                        context.Instructors.Attach(instructor);
                        context.Entry(instructor).State = EntityState.Deleted;
                        context.SaveChanges();

                        this.InstructorsList.ItemsSource =
                            context.Instructors.Include(c => c.Car).ToList();
                    }
                }
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Instructor instructor = this.InstructorsList.SelectedItem as Instructor;
            if (instructor != null)
            {
                var detailWindow = new InstructorDetail(instructor);
                detailWindow.ShowDialog();

                using (var context = new SchoolContext())
                {
                    this.InstructorsList.ItemsSource =
                        context.Instructors.Include(c => c.Car).ToList();
                }
            }

        }
    }
}
