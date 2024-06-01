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
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class Window1 : Window
    {
        Executor exec;

        public Window1()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = this.Login.Text;
            string psswd = this.Password.Text;

            if (login == "" || psswd == "") {
                MessageBox.Show("Ошибка! Все поля должны быть заполнены");
                return;
            }

            using (MobileContext db = new MobileContext())
            {
                foreach (Executor exec in db.Executors)
                {
                    if ($"{exec.Surname}_{exec.Id}" == login && exec.Password == psswd)
                    {
                        this.exec = exec;
                        break;
                    }
                }
            }

            if (this.exec != null)
            {
                Window2 win = new Window2(exec);
                this.Close();
                win.Show();
            } else {
                MessageBox.Show("Неверные данные для входа!");
            }
        }
    }
}
