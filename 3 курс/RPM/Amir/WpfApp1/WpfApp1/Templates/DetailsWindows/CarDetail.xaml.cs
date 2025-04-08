using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using WpfApp1.Base;
using WpfApp1.Base.Entities;

namespace WpfApp1.Templates.DetailsWindows
{
    /// <summary>
    /// Логика взаимодействия для CarDetail.xaml
    /// </summary>
    public partial class CarDetail : Window
    {
        Car car;
        string imgPath;

        public CarDetail(Car car = null)
        {
            InitializeComponent();
            this.car = car;
            
            if (car != null)
            {
                CarNameTB.Text = car.Name;
                CategorySelector.Text = car.Category;
                if (car.Image != null) CarImg.Source = BitmapFrame.Create(new Uri(car.Image));
            }
        }

        private void PickImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            ofd.Multiselect = false;
            ofd.Title = "Select an image";

            bool? result = ofd.ShowDialog();
            if (result == true)
            {
                this.imgPath = ofd.FileName;
                this.CarImg.Source = BitmapFrame.Create(new Uri(this.imgPath));
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Car car;
            if (this.car == null) car = new Car();
            else car = this.car;

            car.Name = this.CarNameTB.Text;
            car.Category = this.CategorySelector.Text;
            car.Image = this.imgPath;

            using (var context = new SchoolContext())
            {
                context.Cars.AddOrUpdate(car);
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
