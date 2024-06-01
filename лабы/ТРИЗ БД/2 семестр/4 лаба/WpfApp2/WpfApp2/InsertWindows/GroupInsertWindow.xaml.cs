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
    /// Логика взаимодействия для GroupInsertWindow.xaml
    /// </summary>
    public partial class GroupInsertWindow : Window
    {
        private readonly Groups _currentGroup = new Groups();
        private readonly trizbd_bdEntities1 _bd = new trizbd_bdEntities1();
        public GroupInsertWindow(Groups gr = null)
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Добавление записи";
            if (gr != null)
            {
                this._currentGroup = gr;
                this.TitleTextBlock.Text = "Редактирование записи";
                GroupNumberOfPeopleTB.Text = _currentGroup.number_of_people.ToString();
                GroupInstructorIdTB.Text = _currentGroup.instructor_id.ToString() ;
                GroupProfessionTB.Text = _currentGroup.profession;
                GroupNumberTB.Text = _currentGroup.group_number.ToString();

            }
            DataContext = _currentGroup;

        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            bool flag = (
                MainWindow.IntCheck(GroupNumberOfPeopleTB.Text) &&
                MainWindow.IntCheck(GroupInstructorIdTB.Text) &&
                MainWindow.IntCheck(GroupNumberTB.Text) &&
                MainWindow.FKExistsCheck(GroupInstructorIdTB.Text, "Instructor")
            );

            if (flag)
            {
                _currentGroup.number_of_people = int.Parse(GroupNumberOfPeopleTB.Text);
                _currentGroup.instructor_id = int.Parse(GroupInstructorIdTB.Text);
                _currentGroup.profession = GroupProfessionTB.Text;
                _currentGroup.group_number = int.Parse(GroupNumberTB.Text);

                trizbd_bdEntities1.GetContext().Group.AddOrUpdate(_currentGroup);
                trizbd_bdEntities1.GetContext().SaveChanges();
                MessageBox.Show("Ура, добавилось!");
                this.Close();
            }
            else { MessageBox.Show("Ошибка! Проверьте данные!"); }
        }
    }
}
