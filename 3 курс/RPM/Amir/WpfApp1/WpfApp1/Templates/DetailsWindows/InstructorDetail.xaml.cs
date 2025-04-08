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
using WpfApp1.Base.Entities;
using WpfApp1.Base;
using System.Data.Entity.Migrations;

namespace WpfApp1.Templates.DetailsWindows
{
    /// <summary>
    /// Логика взаимодействия для InstructorDetail.xaml
    /// </summary>
    public partial class InstructorDetail : Window
    {
        Instructor instructor;

        public InstructorDetail(Instructor instructor = null)
        {
            InitializeComponent();
            this.instructor = instructor;

            using (var context = new SchoolContext())
            {
                this.CarsSelector.ItemsSource = context.Cars.ToList();
            }

            if (instructor != null)
            {
                this.NameTB.Text = instructor.Name;
                this.CategorySelector.Text = instructor.Category;
                this.RoleTB.Text = instructor.Role.ToString();
                this.EmailTB.Text = instructor.Email;
                this.CategorySelector.SelectedItem = instructor.Category;
                this.CarsSelector.SelectedItem = instructor.Car;

            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Instructor instructor;
            if (this.instructor == null) instructor = new Instructor();
            else instructor = this.instructor;

            instructor.Name = this.NameTB.Text;
            instructor.Email = this.EmailTB.Text;
            instructor.Category = this.CategorySelector.Text;
            instructor.Car = this.CarsSelector.SelectedItem as Car;
            if (int.TryParse(this.RoleTB.Text, out int role)) instructor.Role = role;
            else MessageBox.Show("Ошибка! Неверно выбрана роль пользователя");

            using (var context = new SchoolContext())
            {
                context.Instructors.AddOrUpdate(instructor);
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
