using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace WpfApp2.InsertWindows
{
    /// <summary>
    /// Логика взаимодействия для StudentInsertWindow.xaml
    /// </summary>
    public partial class StudentInsertWindow : Window
    {
        private readonly Student _currentStudent = new Student();
        private readonly trizbd_bdEntities1 _bd = new trizbd_bdEntities1();
        public StudentInsertWindow(Student st = null)
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Добавление записи";
            if (st != null)
            {
                this._currentStudent = st;
                this.TitleTextBlock.Text = "Редактирование записи";

                this.StudentSurnameTB.Text = st.surname;
                this.StudentNameTB.Text = st.name;
                this.StudentFirstNameTB.Text = st.name;
                this.StudentGroupNumberTB.Text = st.group_number.ToString();
                this.StudentPhoneNumberTB.Text = st.telephone_number;
                this.StudentCityOfRegistrationTB.Text = st.city_of_registration;
                this.StudentBirthdateTB.Text = st.birth_date;

            }
            DataContext = _currentStudent;

        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            bool flag = (
                MainWindow.IntCheck(this.StudentGroupNumberTB.Text) &&
                MainWindow.IntCheck(this.StudentPhoneNumberTB.Text) &&
                MainWindow.FKExistsCheck(this.StudentGroupNumberTB.Text, "Group") &&
                MainWindow.DateCheck(this.StudentBirthdateTB.Text)
            );


            if (flag)
            {

                _currentStudent.surname = this.StudentSurnameTB.Text;
                _currentStudent.name = this.StudentNameTB.Text;
                _currentStudent.first_name = this.StudentFirstNameTB.Text;
                _currentStudent.group_number = int.Parse(this.StudentGroupNumberTB.Text);
                _currentStudent.telephone_number = this.StudentPhoneNumberTB.Text;
                _currentStudent.city_of_registration = this.StudentCityOfRegistrationTB.Text;
                _currentStudent.birth_date = this.StudentBirthdateTB.Text;

                trizbd_bdEntities1.GetContext().Students.AddOrUpdate(_currentStudent);
                trizbd_bdEntities1.GetContext().SaveChanges();
                MessageBox.Show("Ура, добавилось!");
                this.Close();
            }
            else { MessageBox.Show("Ошибка! Проверьте данные!"); }
        }
    }
}
