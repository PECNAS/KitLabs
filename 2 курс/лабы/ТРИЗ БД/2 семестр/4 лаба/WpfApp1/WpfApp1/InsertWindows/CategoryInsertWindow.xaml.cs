using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    /// Логика взаимодействия для CategoryInsertWindow.xaml
    /// </summary>
    public partial class CategoryInsertWindow : Window
    {
        Category current;
        public CategoryInsertWindow(Executor exec, Category current = null)
        {
            this.current = current;
            InitializeComponent();

            if (current != null)
            {
                CatTitle.Text = current.Title;
                CatPrice.Text = current.Cost.ToString();
                CatDesc.Text = current.Description;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(CatPrice.Text, out int cost)) MessageBox.Show("Ошибка! Цена должна быть в формате числа");
            else
            {
                var cat = new Category
                {
                    Cost = cost,
                    Description = CatDesc.Text,
                    Title = CatTitle.Text
                };
                if (this.current != null) cat.Id = current.Id;

                using (var db = new MobileContext())
                {
                    db.Categories.AddOrUpdate(cat);
                    db.SaveChanges();
                }

                MessageBox.Show("Новая категория успешно добавлена");
                this.Close();
            }
        }
    }
}
