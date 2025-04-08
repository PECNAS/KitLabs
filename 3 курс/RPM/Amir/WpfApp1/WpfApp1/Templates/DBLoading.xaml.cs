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
                using (var context = new SchoolContext())
                {
                    if (!context.Instructors.Any())
                    {
                        context.Instructors.Add(new Instructor
                        {
                            Email = "123",
                            Password = "123123",
                            Role = 1
                        });

                        context.SaveChanges();
                    }

                    if (!context.Cars.Any())
                    {
                        context.Cars.AddRange(new List<Car>()
                        {
                            new Car
                            {
                                Name = "Wolksvagen Polo",
                                Category = "B",
                            },
                            new Car
                            {
                                Name = "Renault Logan",
                                Category = "B",
                            }
                        });
                        context.SaveChanges();
                    }

                    if (!context.Tickets.Any())
                    {
                        context.Tickets.AddRange(new List<Ticket>()
                        {
                            new Ticket
                            {
                                TicketQuest = "Вам можно продолжить движение на перекрестке: ",
                                Image = "../Resources/ticket1.png",
                                TrueAnswer = 1,
                                Answer1 = "Только в направлении Б",
                                Answer2 = "В направлении А и Б",
                                Answer3 = "В направлении Б и В"
                            }
                        });
                        context.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к бд!");
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
