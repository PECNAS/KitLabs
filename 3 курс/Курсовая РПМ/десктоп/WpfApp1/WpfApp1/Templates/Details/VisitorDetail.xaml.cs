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
    /// Логика взаимодействия для VisitorDetail.xaml
    /// </summary>
    public partial class VisitorDetail : Window
    {
        Visitor visitor;
        public VisitorDetail(Visitor visitor = null)
        {
            InitializeComponent();

            using (var context = new HostelContext())
            {
                this.ReservesSelector.ItemsSource = context.Reserves.ToList();
            }

            if (visitor != null)
            {
                this.NameTB.Text = visitor.Name;
                this.PhoneNumberTB.Text = visitor.PhoneNumber;
                this.ReservesSelector.SelectedItem =
                    visitor.Reserves.ToList()[visitor.Reserves.Count - 1];
            }

            this.visitor = visitor;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Visitor visitor;
            if (this.visitor != null) visitor = this.visitor;
            else visitor = new Visitor();

            if (this.NameTB.Text.Replace(" ", "") == "" ||
                !(this.PhoneNumberTB.Text.Length == 12) ||
                !this.PhoneNumberTB.Text.StartsWith("+7"))
            {
                MessageBox.Show(
                    "Неверный формат данных!",
                    "Data Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            visitor.Name = this.NameTB.Text;
            visitor.PhoneNumber = this.PhoneNumberTB.Text;


            if (ReservesSelector.SelectedItem != null)
            {
                visitor.Reserves.Add(this.ReservesSelector.SelectedItem as Reserve);
            }

            using (var context = new HostelContext())
            {
                context.Visitors.AddOrUpdate(visitor);
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
