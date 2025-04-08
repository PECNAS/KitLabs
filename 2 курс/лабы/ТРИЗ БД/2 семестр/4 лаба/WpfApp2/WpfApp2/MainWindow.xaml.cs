using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Windows.Documents;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object[] formats;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new StudentDataWindow();
            win.Show();
            this.Close();
        }

        private void EventBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new EventDataWindow();
            win.Show();
            this.Close();
        }

        private void GroupsBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new GroupsDataWindow();
            win.Show();
            this.Close();

        }

        private void InstructorBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new InstructorDataWindow();
            win.Show();
            this.Close();
        }

        private void SubjectBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new SubjectDataWindow();
            win.Show();
            this.Close();
        }

        private void TimetableBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new TimetableDataWindow();
            win.Show();
            this.Close();
        }

        public static bool DateCheck(string seq) { return DateTime.TryParseExact(seq, "dd.MM.yyyy", null, DateTimeStyles.None, out _); }
        public static bool TimeCheck(string seq) { return TimeSpan.TryParse(seq, out _); }
        public static bool IntCheck(string seq) { return int.TryParse(seq, out _); }
        public static bool FKExistsCheck(string key, string ob)
        {
            // проверяет есть ли в таблице ob запись с кодом key

            if (int.TryParse(key, out int id)) { // поиск идет по первичным ключам типа int, поэтому переделываем string в int
                var context = trizbd_bdEntities1.GetContext();
                if (ob == "Event ") { return context.Events.Find(id) != null; }
                else if (ob == "Student") { return context.Students.Find(id) != null; }
                else if (ob == "Group") { return context.Group.Find(id) != null; }
                else if (ob == "Subject") { return context.Subjects.Find(id) != null; }
                else if (ob == "Timetable") { return context.Timetables.Find(id) != null; }
                else if (ob == "Instructor") { return context.Instructors.Find(id) != null; }
            }
            return false;
        }

    }
}
