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

namespace WpfApp1.Templates
{
    /// <summary>
    /// Логика взаимодействия для DBLoading.xaml
    /// </summary>
    public partial class DBLoading : UserControl
    {
        public DBLoading()
        {
            InitializeComponent();
        }

        public bool ConnectionCheck()
        {
            try
            {
                using (var context = new ShopContext())
                {
                    if (!context.Users.Any())
                    {
                        context.Users.Add(new User
                        {
                            Email = "123",
                            Password = "123123",
                            Role = 1
                        });

                        context.SaveChanges();
                    }

                    if (!context.Items.Any())
                    {
                        context.Items.AddRange(new List<Item>
                        {
                            new Item
                            {
                                Title = "Товар 1",
                                Description = "Описание",
                                Price = 1020,
                                Image = "Resources/img1.jpg",
                                Rating = 5.0
                            },
                            new Item
                            {
                                Title = "Товар 2",
                                Description = "Описание",
                                Price = 1020,
                                Image = "Resources/img1.jpg",
                                Rating = 5.0
                            },
                            new Item
                            {
                                Title = "Товар 3",
                                Description = "Описание",
                                Price = 1020,
                                Image = "Resources/img1.jpg",
                                Rating = 5.0
                            },
                            new Item
                            {
                                Title = "Товар 4",
                                Description = "Описание",
                                Price = 1020,
                                Image = "Resources/img1.jpg",
                                Rating = 5.0
                            },
                            new Item
                            {
                                Title = "Товар 5",
                                Description = "Описание",
                                Price = 1020,
                                Image = "Resources/img1.jpg",
                                Rating = 5.0
                            }
                        });
                        context.SaveChanges();
                    }
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к бд!");
                return false;
            }
        }
    }
}
