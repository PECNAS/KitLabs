using ClosedXML.Excel;
using System.Text;
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
using WpfApp1.Templates;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new MainWidget(this));
            this.PageTitle.Text = "Главная";

            this.AuthBtn.IsEnabled = true;
            this.MainBtn.IsEnabled = false;
            this.BuiesBtn.IsEnabled = true;
            this.ItemsBtn.IsEnabled = true;
            this.UsersBtn.IsEnabled = true;
            this.ExportBtn.IsEnabled = true;
        }

        private void UsersBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new UsersWidget(this));
            this.PageTitle.Text = "Пользователи";

            this.AuthBtn.IsEnabled = true;
            this.MainBtn.IsEnabled = true;
            this.BuiesBtn.IsEnabled = true;
            this.ItemsBtn.IsEnabled = true;
            this.UsersBtn.IsEnabled = false;
            this.ExportBtn.IsEnabled = true;
        }

        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new ItemsWidget(this));
            this.PageTitle.Text = "Товары";

            this.AuthBtn.IsEnabled = true;
            this.MainBtn.IsEnabled = true;
            this.BuiesBtn.IsEnabled = true;
            this.ItemsBtn.IsEnabled = false;
            this.UsersBtn.IsEnabled = true;
            this.ExportBtn.IsEnabled = true;
        }

        private void BuiesBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new BuysWidget(this));
            this.PageTitle.Text = "Покупки";

            this.AuthBtn.IsEnabled = true;
            this.MainBtn.IsEnabled = true;
            this.BuiesBtn.IsEnabled = false;
            this.ItemsBtn.IsEnabled = true;
            this.UsersBtn.IsEnabled = true;
            this.ExportBtn.IsEnabled = true;
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new AuthWidget(this));
            this.PageTitle.Text = "Авторизация";

            this.AuthBtn.IsEnabled = false;
            this.MainBtn.IsEnabled = true;
            this.BuiesBtn.IsEnabled = true;
            this.ItemsBtn.IsEnabled = true;
            this.UsersBtn.IsEnabled = true;
            this.ExportBtn.IsEnabled = true;

            if (this.AuthBtn.Content == "Войти") this.AuthBtn.Content = "Выйти";
            else
            {
                this.AuthBtn.Content = "Войти";
                ButtonEnableChange(false);
            }
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new AuthWidget(this));
            this.PageTitle.Text = "Экспорт";

            this.AuthBtn.IsEnabled = false;
            this.MainBtn.IsEnabled = true;
            this.BuiesBtn.IsEnabled = true;
            this.ItemsBtn.IsEnabled = true;
            this.UsersBtn.IsEnabled = true;
            this.ExportBtn.IsEnabled = true;

            using (var context = new ShopContext())
            {
                var shopCarts = context.ShopCarts.ToList();
                var users = context.Users.ToList();
                var items = context.Items.ToList();

                // Создание нового файла Excel
                var workbook = new XLWorkbook();
                var usersWs = workbook.Worksheets.Add("Пользователи");
                var itemsWs = workbook.Worksheets.Add("Товары");
                var shopCartsWs = workbook.Worksheets.Add("Покупки");

                // Добавление заголовков
                usersWs.Cell(1, 1).Value = "ID";
                usersWs.Cell(1, 2).Value = "Email";
                usersWs.Cell(1, 3).Value = "Пароль";
                usersWs.Cell(1, 4).Value = "Роль";

                itemsWs.Cell(1, 1).Value = "ID";
                itemsWs.Cell(1, 2).Value = "Название";
                itemsWs.Cell(1, 3).Value = "Описание";
                itemsWs.Cell(1, 4).Value = "Цена";
                itemsWs.Cell(1, 5).Value = "Изображение";
                itemsWs.Cell(1, 6).Value = "Рейтинг";

                shopCartsWs.Cell(1, 1).Value = "ID";
                shopCartsWs.Cell(1, 2).Value = "ID пользователя";
                shopCartsWs.Cell(1, 3).Value = "ID товара";

                for (int i = 0; i < users.Count; i++)
                {
                    usersWs.Cell(i + 2, 1).Value = users[i].Id;
                    usersWs.Cell(i + 2, 2).Value = users[i].Email;
                    usersWs.Cell(i + 2, 3).Value = users[i].Password;
                    usersWs.Cell(i + 2, 4).Value = users[i].Role;
                }

                for (int i = 0; i < items.Count; i++)
                {
                    itemsWs.Cell(i + 2, 1).Value = items[i].Id;
                    itemsWs.Cell(i + 2, 2).Value = items[i].Title;
                    itemsWs.Cell(i + 2, 3).Value = items[i].Description;
                    itemsWs.Cell(i + 2, 4).Value = items[i].Price;
                    itemsWs.Cell(i + 2, 4).Value = items[i].Image;
                    itemsWs.Cell(i + 2, 4).Value = items[i].Rating;
                }

                for (int i = 0; i < shopCarts.Count; i++)
                {
                    shopCartsWs.Cell(i + 2, 1).Value = shopCarts[i].Id;
                    shopCartsWs.Cell(i + 2, 2).Value = shopCarts[i].UserId;
                    shopCartsWs.Cell(i + 2, 3).Value = shopCarts[i].ItemId;
                }

                // Сохранение файла на диск
                var filePath = "C:\\File.xlsx"; 
                workbook.SaveAs(filePath);

                MessageBox.Show($"Файл сохранён по пути: {filePath}");
            }

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            var load_widget = new DBLoading();
            this.WidgetPlace.Children.Add(load_widget);

            if (load_widget.ConnectionCheck())
            {
                this.WidgetPlace.Children.Clear();
                this.WidgetPlace.Children.Add(new AuthWidget(this));
            }
            else
            {
                MessageBox.Show("Ошибка подключения к бд!");
            }
        }

        public void ButtonEnableChange(bool flag)
        {
            this.AuthBtn.IsEnabled = flag;
            this.MainBtn.IsEnabled = flag;
            this.BuiesBtn.IsEnabled = flag;
            this.ItemsBtn.IsEnabled = flag;
            this.UsersBtn.IsEnabled = flag;
            this.ExportBtn.IsEnabled = flag;
        }
    }
}