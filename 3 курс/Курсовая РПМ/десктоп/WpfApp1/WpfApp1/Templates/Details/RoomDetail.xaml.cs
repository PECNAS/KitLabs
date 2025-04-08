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
using System.Windows.Shapes;
using WpfApp1.Base.Entities;
using WpfApp1.Base;
using System.Data.Entity.Migrations;

namespace WpfApp1.Templates.Details
{
    /// <summary>
    /// Логика взаимодействия для RoomDetail.xaml
    /// </summary>
    public partial class RoomDetail : Window
    {
        Room room;
        public RoomDetail(Room room = null)
        {
            InitializeComponent();

            using (var context = new HostelContext())
            {
                this.ReservesSelector.ItemsSource = context.Reserves.ToList();
            }

            if (room != null)
            {
                this.RoomNumberTB.Text = room.RoomNumber.ToString();
                this.RoomTypeTB.Text = room.RoomType;
                this.PriceTB.Text = room.Price.ToString();
                this.DescriptionTB.Text = room.Description;
                this.IsFreeCB.IsChecked = room.IsFree;
                this.ReservesSelector.SelectedItem = room.Reserve;
            }

            this.room = room;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Room room;
            if (this.room != null) room = this.room;
            else room = new Room();

            if (int.TryParse(this.RoomNumberTB.Text, out int room_number) &&
                int.TryParse(this.PriceTB.Text, out int price) &&
                this.RoomTypeTB.Text.Replace(" ", "") != "" &&
                this.DescriptionTB.Text.Replace(" ", "") != "")
            {
                room.RoomNumber = room_number;
                room.Price = price;
            } else
            {
                MessageBox.Show(
                    "Неверный формат данных",
                    "Data Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return;
            }

            room.RoomType = this.RoomTypeTB.Text ;
            room.Description = this.DescriptionTB.Text;
            room.IsFree = (bool)this.IsFreeCB.IsChecked;

            using (var context = new HostelContext())
            {
                var reserve = this.ReservesSelector.SelectedItem;
                if (reserve != null)
                {
                    room.Reserve = context.Reserves.FirstOrDefault(
                        r => r.Id == (reserve as Reserve).Id);
                }
                context.Rooms.AddOrUpdate(room);
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
