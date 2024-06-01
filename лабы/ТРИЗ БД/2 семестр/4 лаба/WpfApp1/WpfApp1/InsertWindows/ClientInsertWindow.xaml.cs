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
    /// Логика взаимодействия для ClientInsertWindow.xaml
    /// </summary>
    public partial class ClientInsertWindow : Window
    {
        Client current;
        public ClientInsertWindow(Executor exec, Client current = null)
        {
            this.current = current;
            InitializeComponent();

            if (current != null)
            {
                ClientName.Text = current.Name;
                ClientEmail.Text = current.Email;
                ClientPhoneNumber.Text = current.PhoneNumber;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ClientName.Text == "" || ClientName.Text == " " ||
                ClientEmail.Text == "" || ClientEmail.Text == " "||
                ClientPhoneNumber.Text == "" || ClientPhoneNumber.Text == " " ||
                !long.TryParse(ClientPhoneNumber.Text, out _) || ClientPhoneNumber.Text.Length != 11)
                MessageBox.Show("Все поля должны быть заполнены");
            else
            {
                var client = new Client
                {
                    Name = ClientName.Text,
                    Email = ClientEmail.Text,
                    PhoneNumber = ClientPhoneNumber.Text
                };

                if (current != null) client.Id = current.Id;

                using (var db = new MobileContext())
                {
                    db.Clients.AddOrUpdate(client);
                    db.SaveChanges();
                }
                MessageBox.Show("Новый клиент успешно добавлен!");
                this.Close();
            }
        }
    }
}
