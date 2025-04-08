using Microsoft.Win32;
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
using System.Diagnostics.Eventing.Reader;
using System.Data.Entity.Migrations;

namespace WpfApp1.Templates.DetailsWindows
{
    /// <summary>
    /// Логика взаимодействия для StudentDetail.xaml
    /// </summary>
    public partial class StudentDetail : Window
    {
        Student student;

        public StudentDetail(Student student = null)
        {
            InitializeComponent();
            this.student = student;

            using (var context = new SchoolContext())
            {
                this.InstructorsSelector.ItemsSource = context.Instructors.ToList();
            }

            if (student != null)
            {
                this.NameTB.Text = student.Name;
                this.CategorySelector.Text = student.Category;
                this.EmailTB.Text = student.Email;
                this.StartDateTB.Text = student.StartDate;
                this.EndDateTB.Text = student.EndDate;
                this.InstructorsSelector.SelectedItem = student.Instructor;

            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Student student;
            if (this.student == null) student = new Student();
            else student = this.student;

            student.Name = this.NameTB.Text;
            student.Category = this.CategorySelector.Text;
            student.Email = this.EmailTB.Text;
            student.StartDate = this.StartDateTB.Text;
            student.EndDate = this.EndDateTB.Text;
            student.Instructor = this.InstructorsSelector.SelectedItem as Instructor;

            using (var context = new SchoolContext())
            {
                context.Students.AddOrUpdate(student);
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
