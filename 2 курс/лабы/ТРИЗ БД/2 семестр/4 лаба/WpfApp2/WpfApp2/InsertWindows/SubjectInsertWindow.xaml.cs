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
    /// Логика взаимодействия для SubjectInsertWindow.xaml
    /// </summary>
    public partial class SubjectInsertWindow : Window
    {
        private readonly Subject _currentSubject = new Subject();
        private readonly trizbd_bdEntities1 _bd = new trizbd_bdEntities1();
        public SubjectInsertWindow(Subject sb = null)
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Добавление записи";
            if (sb != null)
            {
                this._currentSubject = sb;
                this.TitleTextBlock.Text = "Редактирование записи";

                this.SubjectGroupNumberTB.Text = sb.group_number.ToString();
                this.SubjectHoursInWeekTB.Text = sb.hours_in_week.ToString();
                this.SubjectNameTB.Text = sb.subject_name;
            }
            DataContext = _currentSubject;

        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            bool flag = (
                MainWindow.IntCheck(this.SubjectGroupNumberTB.Text) &&
                MainWindow.FKExistsCheck(this.SubjectGroupNumberTB.Text, "Group") &&
                MainWindow.IntCheck(this.SubjectHoursInWeekTB.Text)
                );

            if (flag)
            {
                _currentSubject.group_number = int.Parse(this.SubjectGroupNumberTB.Text);
                _currentSubject.hours_in_week = int.Parse(this.SubjectHoursInWeekTB.Text);
                _currentSubject.subject_name = this.SubjectNameTB.Text;


                trizbd_bdEntities1.GetContext().Subjects.AddOrUpdate(_currentSubject);
                trizbd_bdEntities1.GetContext().SaveChanges();
                MessageBox.Show("Ура, добавилось!");
                this.Close();
            }
            else { MessageBox.Show("Ошибка! Проверьте данные!"); }
        }
    }
}
