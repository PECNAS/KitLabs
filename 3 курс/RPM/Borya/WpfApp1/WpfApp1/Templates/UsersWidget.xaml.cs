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
using WpfApp1.Base.Entities;
using WpfApp1.Base;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Net.Mail;
using System.ComponentModel;

namespace WpfApp1.Templates
{
    /// <summary>
    /// Логика взаимодействия для UsersWidget.xaml
    /// </summary>
    public partial class UsersWidget : UserControl
    {
        MainWindow root;
        public UsersWidget(MainWindow root)
        {
            this.root = root;
            InitializeComponent();

            using (var context = new ShopContext())
            {
                this.UsersTable.ItemsSource = context.Users.ToList();

            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ShopContext())
            {
                context.Users.Add(new User
                {
                    Role = 0,
                    Email = "Не задано",
                    Password = "Не задано",
                });
                context.SaveChanges();

                var items = context.Users.ToList();
                this.UsersTable.ItemsSource = items;

                MessageBox.Show("Задайте параметры для нового пользователя");
            }

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var users = this.UsersTable.Items;

            using (var context = new ShopContext())
            {
                foreach (var user in users)
                {
                    if (user.GetType() == typeof(User)) context.Users.AddOrUpdate((User)user);
                }
                context.SaveChanges();
                this.UsersTable.ItemsSource = context.Users.ToList();
            }
            MessageBox.Show("Сохранение прошло успешно!");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = this.UsersTable.SelectedItem as User;
            if (user != null)
            {
                using (var context = new ShopContext())
                {
                    context.Users.Attach(user);
                    context.Entry(user).State = EntityState.Deleted;
                    context.SaveChanges();
                    this.UsersTable.ItemsSource = context.Users.ToList();
                }
                MessageBox.Show("Удаление прошло успешно");
            }
        }
    }
}
