using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApp1.DataWindows;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            new SampleData().FillDatabase();
            InitializeComponent();

            List<string> categroies = new List<string>();
            using (MobileContext db = new MobileContext())
            {
                foreach (Category c in db.Categories)
                {
                    categroies.Add($"{c.Title} | {c.Cost} Рублей");
                }
            }
            this.CategoriesDropDown.ItemsSource = categroies;


            /////////
            //using (MobileContext db = new MobileContext())
            //{
            //    var exec = db.Executors.First(x => x.Id == 1);
            //    var win = new AppDataWindow(exec);
            //    win.Show();
            //    this.Close();
            //}
            /////////
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = this.Email.Text;
            string name = this.Name.Text;
            string phone_number = this.PhoneNumber.Text;
            string category = this.CategoriesDropDown.Text;
            string description = this.Description.Text;

            if (email == "" || name == "" || phone_number == "" || category == "" || description == "")
            {
                MessageBox.Show("Ошибка! Все поля обязательно должны быть заполнены");
                return;
            }

            MobileContext db = new MobileContext();

            Client client = new Client
            {
                Email = email,
                Name = name,
                PhoneNumber = phone_number
            };
            db.Clients.Add(client);
            db.SaveChanges();

            string cat_title = category.Split(" | ")[0];
            int cat_id = db.Categories.FirstOrDefault(x => x.Title == cat_title).Id;

            Models.App app = new Models.App
            {
                ClientId = client.Id,
                CategoryId = cat_id,
                Title = $"{cat_title}",
                Description = description,
                OpenDate = "Не взято",
                CloseDate = ""
            };

            db.Apps.Add(app);
            db.SaveChanges();

            MessageBox.Show("Ваша заявка сохранена и в скором времени будет взята в обработку!\nОжидайте, скоро мы свяжемся с вами по указанным контактным данным");

            this.Email.Text = "";
            this.Name.Text = "";
            this.PhoneNumber.Text = "";
            this.Description.Text = "";
            this.CategoriesDropDown.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            this.Close();
            win.Show();
        }

        public static bool DateCheck(string seq) { return DateTime.TryParseExact(seq, "dd.MM.yyyy", null, DateTimeStyles.None, out _); }
        public static bool IntCheck(string seq) { return int.TryParse(seq, out _); }
        public static bool FKExistsCheck(string key, string ob)
        {
            // проверяет есть ли в таблице ob запись с кодом key
            using (var context = new MobileContext())
            {
                if (int.TryParse(key, out int id))
                { // поиск идет по первичным ключам типа int, поэтому переделываем string в int
                    if (ob == "App") { return context.Apps.Find(id) != null; }
                    else if (ob == "Client") { return context.Clients.Find(id) != null; }
                    else if (ob == "Executor") { return context.Executors.Find(id) != null; }
                    else if (ob == "History") { return context.Histories.Find(id) != null; }
                    else if (ob == "Category") { return context.Categories.Find(id) != null; }
                }
            }
            return false;
        }

    }
}