using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.DirectoryServices.ActiveDirectory;
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
using WpfApp1.Templates.Details;

namespace WpfApp1.Templates.Widgets
{
    /// <summary>
    /// Логика взаимодействия для ReservesWidget.xaml
    /// </summary>
    public partial class ReservesWidget : UserControl
    {
        MainWindow root;
        public ReservesWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new HostelContext())
            {
                this.ReservesList.ItemsSource =
                    context.Reserves.Include("Room").Include("Visitor").ToList();
            }
        }

        public void AddEntity()
        {
            new ReservesDetail().ShowDialog();
            using (var context = new HostelContext())
            {
                this.ReservesList.ItemsSource =
                    context.Reserves.Include("Room").Include("Visitor").ToList();
            }
        }

        public void UpdateEntity()
        {
            var reserve = this.ReservesList.SelectedItem as Reserve;

            if (reserve != null)
            {
                new ReservesDetail(reserve).ShowDialog();
                using (var context = new HostelContext())
                {
                    this.ReservesList.ItemsSource =
                        context.Reserves.Include("Room").Include("Visitor").ToList();
                }
            }

        }

        public void DeleteEntity()
        {
            try
            {
                var item = this.ReservesList.SelectedItem as Reserve;
                if (item != null)
                {
                    using (var context = new HostelContext())
                    {
                        context.Reserves.Attach(item);
                        context.Entry(item).State = EntityState.Deleted;
                        context.SaveChanges();

                        this.ReservesList.ItemsSource =
                            context.Reserves.Include("Room").Include("Visitor").ToList();
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
