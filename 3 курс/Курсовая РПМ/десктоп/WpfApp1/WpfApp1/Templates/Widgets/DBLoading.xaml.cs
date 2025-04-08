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

namespace WpfApp1.Templates.Widgets
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
           /* try
            {*/
                using (var context = new HostelContext())
                {
                    if (!context.Employees.Any())
                    {
                        context.Employees.Add(new Employee
                        {
                            Login = "PECNAS",
                            Name = "Влад",
                            Password = "123123",
                            IsAdmin = true
                        });

                        context.SaveChanges();
                    }

                    if (!context.Rooms.Any())
                    {
                        context.Rooms.AddRange(new List<Room>()
                        {
                            new Room()
                            {
                                RoomNumber = 105,
                                RoomType = "Стандарт",
                                Price = 750,
                                Description = "Стаднартный номер с телефоном, односпальной кроватью и светильником"
                            },
                            new Room()
                            {
                                RoomNumber = 106,
                                RoomType = "Стандарт+",
                                Price = 850,
                                Description = "Номер с телефоном, двуспальной кроватью и светильником"
                            },
                            new Room()
                            {
                                RoomNumber = 200,
                                RoomType = "VIP",
                                Price = 1500,
                                Description = "VIP номер с евро ремонтом"
                            },
                            new Room()
                            {
                                RoomNumber = 201,
                                RoomType = "Президентский",
                                Price = 4000,
                                Description = "Трехкомнатный президентский номер"
                            },

                        });
                        context.SaveChanges();
                    }

                    if (!context.Employees.Any())
                    {
                        context.Employees.AddRange(new List<Employee>()
                        {
                            new Employee
                            {
                                Login = "employee1",
                                Name = "Валентина Степановна",
                                Password = "123123",
                                Position = "Горниная",
                                Wages = 35000
                            },
                            new Employee
                            {
                                Login = "employee2",
                                Name = "Татьяна Борисовна",
                                Password = "123123",
                                Position = "Администратор",
                                Wages = 45000
                            },
                            new Employee
                            {
                                Login = "employee3",
                                Name = "Ольга Борисовна",
                                Password = "123123",
                                Position = "Старший администратор",
                                Wages = 60000
                            },
                        });
                        context.SaveChanges();
                    }
                }

                return true;
            /*
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к бд!");
                MessageBox.Show(ex.ToString());
                return false;
            }*/
        }
    }
}
