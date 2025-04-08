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
using WpfApp1.Templates.Details;
using System.Data.Entity;

namespace WpfApp1.Templates.Widgets
{
    /// <summary>
    /// Логика взаимодействия для RoomsWidget.xaml
    /// </summary>
    public partial class RoomsWidget : UserControl
    {
        MainWindow root;
        public RoomsWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new HostelContext())
            {
                this.RoomsList.ItemsSource =
                    context.Rooms.Include("Reserve").ToList();
            }
        }

        public void AddEntity()
        {
            new RoomDetail().ShowDialog();
            using (var context = new HostelContext())
            {
                this.RoomsList.ItemsSource =
                    context.Rooms.Include("Reserve").ToList();
            }
        }

        public void UpdateEntity()
        {
            var room = this.RoomsList.SelectedItem as Room;

            if (room != null)
            {
                new RoomDetail(room).ShowDialog();
                using (var context = new HostelContext())
                {
                    this.RoomsList.ItemsSource =
                        context.Rooms.Include("Reserve").ToList();
                }
            }

        }

        public void DeleteEntity()
        {
            try
            {
                var item = this.RoomsList.SelectedItem as Room;
                if (item != null)
                {
                    using (var context = new HostelContext())
                    {
                        context.Rooms.Attach(item);
                        context.Entry(item).State = EntityState.Deleted;
                        context.SaveChanges();

                        this.RoomsList.ItemsSource =
                            context.Rooms.Include("Reserve").ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка удаления! Есть связанные объекты",
                    "Delete Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
