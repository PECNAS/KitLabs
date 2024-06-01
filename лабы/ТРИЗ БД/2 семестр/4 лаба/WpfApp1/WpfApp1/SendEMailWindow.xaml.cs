using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using System.Data.Entity.Migrations;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для SendEMailWindow.xaml
    /// </summary>
    public partial class SendEMailWindow : Window
    {
        Executor exec;
        Client client;
        Models.App app;

        public SendEMailWindow(Models.App app, Client client, Executor exec)
        {
            this.exec = exec;
            this.client = client;
            this.app = app;

            InitializeComponent();

            this.EmailTextBox.Text += $"<h3>Здравствуйте, {client.Name}!</h3>\r\n\r\n" +
                $"Ответ по заявке <em>{app.Title}</em>\r\n\r\n\r\n\r\n\r\n" +
                $"С уважением, {exec.Name}";
        }

        public void SendEmail(object sender, RoutedEventArgs e)
        {
            MailAddress from = new MailAddress(exec.Email, exec.Name);
            MailAddress to = new MailAddress(client.Email);
            MailMessage m = new MailMessage(from, to);
            
            m.Subject = "Ответ по заявке от AdPromouter";
            m.Body = this.EmailTextBox.Text;
            m.IsBodyHtml = true;
            
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
            smtp.Credentials = new NetworkCredential(exec.Email, exec.EmailKey);
            smtp.EnableSsl = true;
            smtp.Send(m);

            using (MobileContext db = new MobileContext())
            {
                db.Histories.Add(new History
                {
                    ExecId = this.exec.Id,
                    AppId = this.app.Id
                });

                app.OpenDate = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}";
                db.Apps.AddOrUpdate(app);
                db.SaveChanges();

            }

            MessageBox.Show("Сообщение отправлено!");
            this.Close();
        }
    }
}
