using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
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
using WpfApp1.Base.Entities;

namespace WpfApp1.Templates
{
    /// <summary>
    /// Логика взаимодействия для ItemsWidget.xaml
    /// </summary>
    public partial class ItemsWidget : UserControl
    {
        MainWindow root;
        public ItemsWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new ShopContext())
            {
                this.ItemsTable.ItemsSource = context.Items.ToList();
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ShopContext())
            {
                context.Items.Add(new Item
                {
                    Title = "Не задано",
                    Description = "Не задано",
                    Image = "Не задано",
                    Price = 000000,
                    Rating = 0.0
                });
                context.SaveChanges();

                var items = context.Items.ToList();
                this.ItemsTable.ItemsSource = items;

                MessageBox.Show("Задайте параметры для нового товара");
            }

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = this.ItemsTable.Items;

            using (var context = new ShopContext())
            {
                foreach (var item in items)
                {
                    if (item.GetType() == typeof(Item)) context.Items.AddOrUpdate((Item)item);
                }
                context.SaveChanges();
                this.ItemsTable.ItemsSource = context.Items.ToList();
            }
            MessageBox.Show("Сохранение прошло успешно!");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = this.ItemsTable.SelectedItem as Item;
            if (item != null)
            {
                using (var context = new ShopContext())
                {
                    context.Items.Attach(item);
                    context.Entry(item).State = EntityState.Deleted;
                    context.SaveChanges();
                    this.ItemsTable.ItemsSource = context.Items.ToList();
                }
                MessageBox.Show("Удаление прошло успешно");
            }
        }
    }
}
