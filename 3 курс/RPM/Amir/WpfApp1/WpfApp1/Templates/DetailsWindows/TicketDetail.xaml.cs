using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для TicketDetail.xaml
    /// </summary>
    public partial class TicketDetail : Window
    {
        Ticket ticket;
        string imgPath;

        public TicketDetail(Ticket ticket = null)
        {
            InitializeComponent();

            if (ticket != null)
            {
                this.TicketQuestTB.Text = ticket.TicketQuest;
                this.Answer1TB.Text = ticket.Answer1;
                this.Answer2TB.Text = ticket.Answer2;
                this.Answer3TB.Text = ticket.Answer3;
                this.TrueAnswerSelector.SelectedIndex = ticket.TrueAnswer - 1;
                if (ticket.Image != null) TicketImg.Source = BitmapFrame.Create(new Uri(ticket.Image));

                this.imgPath = ticket.Image;
            }

            this.ticket = ticket;
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
                this.TicketImg.Source = BitmapFrame.Create(new Uri(this.imgPath));
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket;
            if (this.ticket == null) ticket = new Ticket();
            else ticket = this.ticket;

            ticket.TicketQuest = this.TicketQuestTB.Text;
            ticket.Answer1 = this.Answer1TB.Text;
            ticket.Answer2 = this.Answer2TB.Text;
            ticket.Answer3 = this.Answer3TB.Text;
            ticket.Image = this.imgPath;
            ticket.TrueAnswer = this.TrueAnswerSelector.SelectedIndex + 1;

            using (var context = new SchoolContext())
            {
                context.Tickets.AddOrUpdate(ticket);
                context.SaveChanges();
            }

            this.Close();
        }
    }
}
