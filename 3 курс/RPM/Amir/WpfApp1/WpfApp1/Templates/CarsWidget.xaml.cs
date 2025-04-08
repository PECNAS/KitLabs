using System;
using System.Collections.Generic;
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
using WpfApp1.Templates.DetailsWindows;

namespace WpfApp1.Templates
{
    /// <summary>
    /// Логика взаимодействия для CarsWidget.xaml
    /// </summary>
    public partial class CarsWidget : UserControl
    {
        MainWindow root;
        public CarsWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new SchoolContext())
            {
                this.CarsList.ItemsSource = context.Cars.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new CarDetail();
            detailWindow.ShowDialog();

            using (var context = new SchoolContext())
            {
                this.CarsList.ItemsSource = context.Cars.ToList();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Car car = this.CarsList.SelectedItem as Car;
            if (car != null)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить {car.Name}?",
                    "Delete object",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    using (var context = new SchoolContext())
                    {
                        context.Cars.Attach(car);
                        context.Entry(car).State = EntityState.Deleted;
                        context.SaveChanges();

                        this.CarsList.ItemsSource = context.Cars.ToList();
                    }
                }
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Car car = this.CarsList.SelectedItem as Car;
            if (car != null)
            {
                var detailWindow = new CarDetail(car);
                detailWindow.ShowDialog();

                using (var context = new SchoolContext())
                {
                    this.CarsList.ItemsSource = context.Cars.ToList();
                }
            }

        }
    }
}
