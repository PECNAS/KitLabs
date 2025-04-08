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

namespace WpfApp1.Templates.Widgets
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
            using (var context = new HostelContext())
            {
                if (context.Employees.FirstOrDefault(
                    e => e.Login == LoginTB.Text &&
                    e.Password == PasswordTB.Text &&
                    e.IsAdmin == true) != null)
                {
                    root.WidgetPlace.Children.Clear();
                    root.employeesWidget = new EmployeesWidget(root);
                    root.WidgetPlace.Children.Add(root.employeesWidget);

                    root.ExportBtn.IsEnabled = true;
                    root.EmployeesBtn.IsEnabled = true;
                    root.RoomsBtn.IsEnabled = true;
                    root.ReservesBtn.IsEnabled = true;
                    root.VisitorsBtn.IsEnabled = true;

                    root.BtnsPanel.Visibility = Visibility.Visible;
                    root.TitleTBlock.Text = "Сотрудники";
                }
                else
                    MessageBox.Show("Ошибка доступа! У вас недостаточно прав!",
                        "Access denied",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);

            }
        }
    }
}
