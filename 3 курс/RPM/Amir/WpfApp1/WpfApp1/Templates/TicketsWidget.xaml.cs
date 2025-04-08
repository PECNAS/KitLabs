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
    /// Логика взаимодействия для TicketsWidget.xaml
    /// </summary>
    public partial class TicketsWidget : UserControl
    {
        MainWindow root;
        public TicketsWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new SchoolContext())
            {
                var tickets = context.Tickets.ToList();
                this.TicketsList.ItemsSource = tickets;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new TicketDetail();
            detailWindow.ShowDialog();

            using (var context = new SchoolContext())
            {
                this.TicketsList.ItemsSource = context.Tickets.ToList();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = this.TicketsList.SelectedItem as Ticket;
            if (ticket != null)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить {ticket.Id} билет?",
                    "Delete object",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    using (var context = new SchoolContext())
                    {
                        context.Tickets.Attach(ticket);
                        context.Entry(ticket).State = EntityState.Deleted;
                        context.SaveChanges();

                        this.TicketsList.ItemsSource = context.Tickets.ToList();
                    }
                }
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = this.TicketsList.SelectedItem as Ticket;
            if (ticket != null)
            {
                var detailWindow = new TicketDetail(ticket);
                detailWindow.ShowDialog();

                using (var context = new SchoolContext())
                {
                    this.TicketsList.ItemsSource = context.Tickets.ToList();
                }
            }

        }
    }
}
