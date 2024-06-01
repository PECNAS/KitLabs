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
    /// Логика взаимодействия для TimetableInsertWindow.xaml
    /// </summary>
    public partial class TimetableInsertWindow : Window
    {
        private readonly Timetable _currentTB = new Timetable();
        private readonly trizbd_bdEntities1 _bd = new trizbd_bdEntities1();
        public TimetableInsertWindow(Timetable tb = null)
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Добавление записи";
            if (tb != null)
            {
                this._currentTB = tb;
                this.TitleTextBlock.Text = "Редактирование записи";

                this.TimetableAudienceTB.Text = tb.audience.ToString();
                this.TimetableGroupNumber.Text = tb.group_number.ToString();
                this.TimetableSubjectTB.Text = tb.subject_id.ToString();
                this.TimetableTimeTB.Text = tb.time_timetable.ToString();

            }
            DataContext = _currentTB;

        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            bool flag = (
                MainWindow.IntCheck(this.TimetableAudienceTB.Text) &&
                MainWindow.IntCheck(this.TimetableGroupNumber.Text) &&
                MainWindow.FKExistsCheck(this.TimetableGroupNumber.Text, "Timetable") &&
                MainWindow.IntCheck(this.TimetableSubjectTB.Text)
                );

            if (flag)
            {
                _currentTB.audience = int.Parse(this.TimetableAudienceTB.Text);
                _currentTB.group_number = int.Parse(this.TimetableGroupNumber.Text);
                _currentTB.subject_id = int.Parse(this.TimetableSubjectTB.Text);
                _currentTB.time_timetable = this.TimetableTimeTB.Text;

                trizbd_bdEntities1.GetContext().Timetables.AddOrUpdate(_currentTB);
                trizbd_bdEntities1.GetContext().SaveChanges();
                MessageBox.Show("Ура, добавилось!");
                this.Close();
            } else { MessageBox.Show("Ошибка! Проверьте данные!"); }
        }
    }
}
