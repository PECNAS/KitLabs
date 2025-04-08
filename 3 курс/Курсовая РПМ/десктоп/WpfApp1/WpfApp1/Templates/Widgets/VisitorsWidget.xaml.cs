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
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data.Entity;

namespace WpfApp1.Templates.Widgets
{
    /// <summary>
    /// Логика взаимодействия для VisitorsWidget.xaml
    /// </summary>
    public partial class VisitorsWidget : UserControl
    {
        MainWindow root;
        public VisitorsWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new HostelContext())
            {
                this.VisitorsList.ItemsSource =
                    context.Visitors.Include("Reserves").ToList();
            }
        }

        public void AddEntity()
        {
            new VisitorDetail().ShowDialog();
            using (var context = new HostelContext())
            {
                this.VisitorsList.ItemsSource =
                    context.Visitors.Include("Reserves").ToList();
            }
        }

        public void UpdateEntity()
        {
            var visitor = this.VisitorsList.SelectedItem as Visitor;

            if (visitor != null)
            {
                new VisitorDetail(visitor).ShowDialog();
                using (var context = new HostelContext())
                {
                    this.VisitorsList.ItemsSource =
                        context.Visitors.Include("Reserves").ToList();
                }
            }
        }

        public void DeleteEntity()
        {
            try
            {
                var item = this.VisitorsList.SelectedItem as Visitor;
                if (item != null)
                {
                    using (var context = new HostelContext())
                    {
                        context.Visitors.Attach(item);
                        context.Entry(item).State = EntityState.Deleted;
                        context.SaveChanges();

                        this.VisitorsList.ItemsSource =
                                context.Visitors.Include("Reserves").ToList();
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
