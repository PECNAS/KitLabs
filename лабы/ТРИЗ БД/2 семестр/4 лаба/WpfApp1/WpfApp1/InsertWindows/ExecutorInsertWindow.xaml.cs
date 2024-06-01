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
using WpfApp1.Models;

namespace WpfApp1.InsertWindows
{
    /// <summary>
    /// Логика взаимодействия для ExecutorInsertWindow.xaml
    /// </summary>
    public partial class ExecutorInsertWindow : Window
    {
        Executor current;
        public ExecutorInsertWindow(Executor exec, Executor current = null)
        {
            this.current = current;
            InitializeComponent();

            if (current != null)
            {
                ExecEmail.Text = current.Email;
                ExecEmailKey.Text = current.EmailKey;
                ExecName.Text = current.Name;
                ExecPassword.Text = current.Password;
                ExecPost.Text = current.Post;
                ExecSurname.Text = current.Surname;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ExecEmail.Text == "" || ExecEmail.Text == " ") MessageBox.Show("Все поля должны быть заполнены");
            else if (ExecEmailKey.Text == "" || ExecEmailKey.Text == " ") MessageBox.Show("Все поля должны быть заполнены");
            else if (ExecName.Text == "" || ExecName.Text == " ") MessageBox.Show("Все поля должны быть заполнены");
            else if (ExecPassword.Text == "" || ExecPassword.Text == " ") MessageBox.Show("Все поля должны быть заполнены");
            else if (ExecPost.Text == "" || ExecPost.Text == " ") MessageBox.Show("Все поля должны быть заполнены");
            else if (ExecSurname.Text == "" || ExecSurname.Text == " ") MessageBox.Show("Все поля должны быть заполнены");
            else
            {
                var exec = new Executor
                {
                    Email = ExecEmail.Text,
                    EmailKey = ExecEmailKey.Text,
                    Name = ExecName.Text,
                    Password = ExecPassword.Text,
                    Post = ExecPost.Text,
                    Surname = ExecSurname.Text
                };

                if (current != null) exec.Id = current.Id;

                using (var db = new MobileContext())
                {
                    db.Executors.AddOrUpdate(exec);
                    db.SaveChanges();
                }
                MessageBox.Show("Новый исполнитель успешно добавлен!");
                this.Close();
            }
        }
    }
}
