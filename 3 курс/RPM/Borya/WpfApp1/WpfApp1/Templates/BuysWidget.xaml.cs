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
using ClosedXML.Excel;

namespace WpfApp1.Templates
{
    /// <summary>
    /// Логика взаимодействия для BuysWidget.xaml
    /// </summary>
    public partial class BuysWidget : UserControl
    {
        MainWindow root;
        public BuysWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new ShopContext())
            {
                this.DataTable.ItemsSource = context.ShopCarts.ToList();
            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ShopContext())
            {
                context.ShopCarts.Add(new ShopCart
                {
                    UserId = -1,
                    ItemId = -1
                });
                context.SaveChanges();

                var items = context.ShopCarts.ToList();
                this.DataTable.ItemsSource = items;

                MessageBox.Show("Задайте параметры для нового пользователя");
            }

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var scs = this.DataTable.Items;

            using (var context = new ShopContext())
            {
                foreach (var sc in scs)
                {
                    if (sc.GetType() == typeof(ShopCart)) context.ShopCarts.AddOrUpdate((ShopCart)sc);
                }
                context.SaveChanges();
                this.DataTable.ItemsSource = context.ShopCarts.ToList();
            }
            MessageBox.Show("Сохранение прошло успешно!");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var sc = this.DataTable.SelectedItem as ShopCart;
            if (sc != null)
            {
                using (var context = new ShopContext())
                {
                    context.ShopCarts.Attach(sc);
                    context.Entry(sc).State = EntityState.Deleted;
                    context.SaveChanges();
                    this.DataTable.ItemsSource = context.ShopCarts.ToList();
                }
                MessageBox.Show("Удаление прошло успешно");
            }
        }
    }
}
