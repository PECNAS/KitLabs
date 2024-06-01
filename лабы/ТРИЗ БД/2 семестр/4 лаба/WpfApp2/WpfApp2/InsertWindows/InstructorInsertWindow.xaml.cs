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
    /// Логика взаимодействия для InstructorInsertWindow.xaml
    /// </summary>
    public partial class InstructorInsertWindow : Window
    {
        private readonly Instructor _currentInstructor = new Instructor();
        private readonly trizbd_bdEntities1 _bd = new trizbd_bdEntities1();
        public InstructorInsertWindow(Instructor ins = null)
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Добавление записи";
            if (ins != null)
            {
                this.InstructionSurnameTB.Text = ins.surname;
                this.InstructionFirstNameTB.Text = ins.first_name;
                this.InstructionNameTB.Text = ins.name;
                this.InstructionBirthdateTB.Text = ins.birth_date;
                this.InstructionPhoneNumberTB.Text = ins.telephone_number;
                this.InstructionPasswordTB.Text = ins.password;
            }
            DataContext = _currentInstructor;

        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            bool flag = (
                MainWindow.IntCheck(this.InstructionPhoneNumberTB.Text) &&
                MainWindow.DateCheck(InstructionBirthdateTB.Text)
            );

            if (flag)
            {
                _currentInstructor.surname = this.InstructionSurnameTB.Text;
                _currentInstructor.name = this.InstructionFirstNameTB.Text;
                _currentInstructor.first_name = this.InstructionNameTB.Text;
                _currentInstructor.birth_date = this.InstructionBirthdateTB.Text;
                _currentInstructor.telephone_number = this.InstructionPhoneNumberTB.Text;
                _currentInstructor.password = this.InstructionPasswordTB.Text;

                trizbd_bdEntities1.GetContext().Instructors.AddOrUpdate(_currentInstructor);
                trizbd_bdEntities1.GetContext().SaveChanges();
                MessageBox.Show("Ура, добавилось!");
                this.Close();
            }
            else { MessageBox.Show("Ошибка! Проверьте данные!"); }
        }
    }
}
