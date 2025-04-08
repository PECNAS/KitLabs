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
using WpfApp1.Templates.Details;

namespace WpfApp1.Templates.Widgets
{
    /// <summary>
    /// Логика взаимодействия для EmployeesWidget.xaml
    /// </summary>
    public partial class EmployeesWidget : UserControl
    {
        MainWindow root;
        public EmployeesWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;

            using (var context = new HostelContext())
            {
                this.EmployeesList.ItemsSource = context.Employees.ToList();
            }
        }

        public void AddEntity()
        {
            new EmployeeDetail().ShowDialog();
            using (var context = new HostelContext())
            {
                this.EmployeesList.ItemsSource = context.Employees.ToList();
            }
        }

        public void UpdateEntity()
        {
            var empl = this.EmployeesList.SelectedItem as Employee;

            if (empl != null)
            {
                new EmployeeDetail(empl).ShowDialog();
                using (var context = new HostelContext())
                {
                    this.EmployeesList.ItemsSource = context.Employees.ToList();
                }
            }

        }

        public void DeleteEntity()
        {
            try
            {
                var item = this.EmployeesList.SelectedItem as Employee;
                if (item != null)
                {
                    using (var context = new HostelContext())
                    {
                        context.Employees.Attach(item);
                        context.Entry(item).State = EntityState.Deleted;
                        context.SaveChanges();

                        this.EmployeesList.ItemsSource = context.Employees.ToList();
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
