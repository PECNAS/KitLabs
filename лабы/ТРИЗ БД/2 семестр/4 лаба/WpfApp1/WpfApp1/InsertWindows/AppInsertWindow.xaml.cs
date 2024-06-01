using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics.Tracing;
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
    /// Логика взаимодействия для AppInsertWindow.xaml
    /// </summary>
    public partial class AppInsertWindow : Window
    {
        Models.App current;
        public AppInsertWindow(Executor exec, Models.App current = null)
        {
            this.current = current;
            InitializeComponent();
            List<string> categroies = new List<string>();
            using (MobileContext db = new MobileContext())
            {
                int i = 0;
                foreach (Category c in db.Categories)
                {
                    categroies.Add($"{c.Title} | {c.Cost} Рублей");
                    if (current != null) { if (current.CategoryId == c.Id) CategoriesDropDown.SelectedIndex = i; }
                    i++;
                }
            }
            this.CategoriesDropDown.ItemsSource = categroies;

            if (current != null)
            {
                AppClientId.Text = current.ClientId.ToString();
                AppOpenDate.Text = current.OpenDate;
                AppCloseDate.Text = current.CloseDate;
                AppDescription.Text = current.Description;
                AppTitle.Text = current.Title; 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(AppClientId.Text, out int client_id)) MessageBox.Show("Ошибка id клиента");
            else if (!MainWindow.FKExistsCheck(AppClientId.Text, "Client")) MessageBox.Show("Ошибка! Несуществующий id пользователя");
            else if (AppOpenDate.Text != "Не взято" && !MainWindow.DateCheck(AppOpenDate.Text)) MessageBox.Show("Ошибка! Неверный формат даты");
            else
            {
                using (var db = new MobileContext())
                {
                    string cat_title = CategoriesDropDown.Text.Split(" | ")[0];
                    int cat_id = db.Categories.FirstOrDefault(x => x.Title == cat_title).Id;

                    var app = new Models.App
                    {
                        ClientId = client_id,
                        CategoryId = cat_id,
                        Description = AppDescription.Text,
                        Title = AppTitle.Text,
                        OpenDate = AppOpenDate.Text,
                        CloseDate = ""
                    };

                    if (current != null) app.Id = current.Id;

                    db.Apps.AddOrUpdate(app);
                    db.SaveChanges();
                }
                MessageBox.Show("Заявка успешно добавлена");
                this.Close();
            }
        }
    }
}
