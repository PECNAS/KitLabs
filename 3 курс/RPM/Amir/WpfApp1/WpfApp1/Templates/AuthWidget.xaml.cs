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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Base;
using WpfApp1.Base.Entities;

namespace WpfApp1.Templates
{
    /// <summary>
    /// Логика взаимодействия для AuthWidget.xaml
    /// </summary>
    public partial class AuthWidget : UserControl
    {
        MainWindow root;
        public AuthWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new SchoolContext())
            {
                string email = EmailTB.Text;
                string psswd = PasswordTB.Text;
                Instructor user = context.Instructors.FirstOrDefault(x => x.Email == email && x.Password == psswd);
                if (user != null)
                {
                    if (user.Role == 0)
                    {
                        MessageBox.Show("Недостаточно прав");
                        return;
                    }
                    MessageBox.Show("Вход успешен!");

                    var new_widget = new MainWidget(root);
                    root.WidgetPlace.Children.Clear();
                    root.WidgetPlace.Children.Add(new_widget);

                    root.BtnsEnabledChange(true);
                }
                else MessageBox.Show("Ошибка! Неверные данные");
            }
        }
    }
}
