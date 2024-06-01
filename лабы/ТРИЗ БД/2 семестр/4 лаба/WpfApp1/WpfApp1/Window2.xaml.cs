using WpfApp1.Models;
using System.Windows;
using System.Windows.Controls;
using System.Net.Mail;
using System.Net;
using System.Data.Entity.Migrations;
using Microsoft.VisualBasic;
using WpfApp1.DataWindows;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Executor exec;
        public Window2(Executor exec)
        {
            InitializeComponent();
            this.exec = exec;

            this.MyApps.Visibility = Visibility.Hidden;
            this.SubmitAppButton.Visibility = Visibility.Hidden;
            this.CloseApp.Visibility = Visibility.Hidden;

            this.SubmitAppButton.IsEnabled = false;
            this.CloseApp.IsEnabled = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.MyApps.Visibility = Visibility.Visible;
            this.SubmitAppButton.Visibility = Visibility.Hidden;
            this.CloseApp.Visibility = Visibility.Visible;
            this.SubmitAppButton.IsEnabled = false;
            this.CloseApp.IsEnabled = false;
            this.AppsMenuItem.Header = "_Мои заявки";

            List<object> apps = new List<object>();

            using (MobileContext db = new MobileContext())
            {
                var my_history = db.Histories.Where(x => x.ExecId == exec.Id);
                if (my_history.Count() != 0)
                {
                    foreach (History his in my_history)
                    {
                        Models.App app = db.Apps.FirstOrDefault(x => x.Id == his.AppId && x.CloseDate == "");
                        if (app != null)
                        {
                            Client client = db.Clients.First(x => x.Id == app.ClientId);

                            string title = $"Заказчик: {client.Name}\r\n";
                            string contacts = $"Контактные данные: {client.Email} | {client.PhoneNumber}";
                            string content = $"Описание заявки: {app.Description}\r\n";
                            string dates = $"Взята в работу: {app.OpenDate}\r\n" +
                                $"Закончена: {app.CloseDate}";

                            apps.Add(new ListBoxElement
                                {
                                    Content = content,
                                    Title = title,
                                    Dates = dates,
                                    Contacts = contacts,
                                    AppId = app.Id
                                }
                            );
                        }
                    }
                }
                else
                {
                    apps.Add(new ListBoxElement { Title = null,  Content = "Сейчас нет ни одной открытой заявки" } );
                }
            }

            this.MyApps.ItemsSource = apps;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.MyApps.Visibility = Visibility.Visible;
            this.SubmitAppButton.Visibility = Visibility.Visible;
            this.CloseApp.Visibility = Visibility.Hidden;

            this.SubmitAppButton.IsEnabled = false;
            this.CloseApp.IsEnabled = false;

            this.AppsMenuItem.Header = "_Открытые заявки";

            List<object> apps = new List<object>();

            using (MobileContext db = new MobileContext())
            {
                var open_apps = db.Apps.Where(x => x.OpenDate == "Не взято");

                if (open_apps.Count() != 0)
                {
                    foreach (Models.App app in open_apps)
                    {
                        Client client = db.Clients.First(x => x.Id == app.ClientId);

                        string title = $"Заявка №{app.Id}\r\nЗаказчик: {client.Name}\r\n";
                        string contacts = $"Контактные данные: {client.Email} | {client.PhoneNumber}";
                        string content = $"Описание заявки: {app.Description}\r\n";
                        string dates = $"Взята в работу: {app.OpenDate}\r\n" +
                            $"Закончена: {app.CloseDate}";

                        apps.Add( new ListBoxElement{
                                Content = content,
                                Title = title,
                                Dates = dates,
                                Contacts = contacts,
                                AppId = app.Id
                            }
                        );
                    }
                }
                else
                {
                    apps.Add(new ListBoxElement { Title = null, Content = "Сейчас нет ни одной открытой заявки" });
                }
            }

            this.MyApps.ItemsSource = apps;
        }

        private void SubmitAppButton_Click(object sender, RoutedEventArgs e)
        {
            int app_id = (this.MyApps.SelectedItem as ListBoxElement).AppId;

            using (MobileContext db = new MobileContext())
            {
                Models.App app = db.Apps.First(x => x.Id == app_id);
                Client client = db.Clients.First(x => x.Id == app.ClientId);

                SendEMailWindow win = new SendEMailWindow(app, client, this.exec);
                win.ShowDialog();
            }

        }

        private void AppSelect(object sender, SelectionChangedEventArgs e)
        {
            if (this.MyApps.SelectedItem != null)
            {
                if ((this.MyApps.SelectedItem as ListBoxElement).Title != null)
                {
                    this.SubmitAppButton.IsEnabled = true;
                    this.CloseApp.IsEnabled = true;
                }
            }
        }

        private void UpdateListBox(object sender, EventArgs e)
        {
            this.MyApps.Visibility = Visibility.Hidden;
            this.SubmitAppButton.Visibility = Visibility.Hidden;
            this.CloseApp.Visibility = Visibility.Hidden;

            this.SubmitAppButton.IsEnabled = false;
            this.CloseApp.IsEnabled = false;
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            int app_id = (this.MyApps.SelectedItem as ListBoxElement).AppId;
            using (MobileContext db = new MobileContext())
            {
                Models.App app = db.Apps.First(x => x.Id == app_id);
                app.CloseDate = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}";

                Client client = db.Clients.First(x => x.Id == app.ClientId);

                db.Apps.AddOrUpdate(app);
                db.SaveChanges();

                MailAddress from = new MailAddress(exec.Email, exec.Name);
                MailAddress to = new MailAddress(client.Email);
                MailMessage m = new MailMessage(from, to);

                m.Subject = "Заявка закрыта | AdPromouter";
                m.Body = $"{client.Name}, ваша заявка {app.Title} выполнена и закрыта." +
                    $"По всем вопросам обращаться по контактам вашего исполнителя: " +
                    $"{exec.Email}";
                m.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
                smtp.Credentials = new NetworkCredential(exec.Email, exec.EmailKey);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }

            MessageBox.Show("Заявка успешно завершена!");
            this.UpdateListBox(sender, e);
        }


        private void DataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var win = new AppDataWindow(this.exec);
            win.Show();
            this.Close();
        }
    }

    public class ListBoxElement
    {
        public string Content {get; set; }
        public string Title {get; set; }
        public string Dates {get; set; }
        public string Contacts {get; set; }
        public int AppId { get; set; }
    }
}
