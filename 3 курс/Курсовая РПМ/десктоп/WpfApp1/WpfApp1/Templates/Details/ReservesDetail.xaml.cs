using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
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

namespace WpfApp1.Templates.Details
{
    /// <summary>
    /// Логика взаимодействия для ReservesDetail.xaml
    /// </summary>
    public partial class ReservesDetail : Window
    {
        Reserve reserve;
        public ReservesDetail(Reserve reserve = null)
        {
            InitializeComponent();

            using (var context = new HostelContext())
            {
                this.VisitorSelector.ItemsSource = context.Visitors.ToList();
                this.RoomSelector.ItemsSource = context.Rooms.ToList();
            }

            if (reserve != null)
            {
                this.StartDateTB.Text = reserve.StartDate;
                this.EndDateTB.Text = reserve.EndDate;
                this.VisitorSelector.SelectedItem = reserve.Visitor;
                this.RoomSelector.SelectedItem = reserve.Room;
            }

            this.reserve = reserve;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Reserve reserve;
            if (this.reserve != null) reserve = this.reserve;
            else reserve = new Reserve();

            reserve.StartDate = this.StartDateTB.Text;
            reserve.EndDate = this.EndDateTB.Text;

            if (VisitorSelector.SelectedItem == null || RoomSelector.SelectedItem == null ||
                this.StartDateTB.Text.Replace(" ", "") == "" ||
                this.EndDateTB.Text.Replace(" ", "") == "" ||
                !DateOnly.TryParse(this.StartDateTB.Text, out DateOnly start_date) ||
                !DateOnly.TryParse(this.EndDateTB.Text, out DateOnly end_date))
            {
                MessageBox.Show(
                    "Неверный формат данных!",
                    "Data Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var visitor = this.VisitorSelector.SelectedItem as Visitor;
            var room = this.RoomSelector.SelectedItem as Room;

            using (var context = new HostelContext())
            {
                reserve.Visitor = context.Visitors.FirstOrDefault(v => v.Id == visitor.Id);
                reserve.Room = context.Rooms.FirstOrDefault(r => r.Id == room.Id);
                context.Reserves.AddOrUpdate(reserve);
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
