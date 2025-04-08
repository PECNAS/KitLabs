using DocumentFormat.OpenXml.Drawing.Diagrams;
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

namespace WpfApp1.Templates.Details
{
    /// <summary>
    /// Логика взаимодействия для EmployeeDetail.xaml
    /// </summary>
    public partial class EmployeeDetail : Window
    {
        Employee empl;
        public EmployeeDetail(Employee empl = null)
        {
            InitializeComponent();

            if (empl != null)
            {
                this.NameTB.Text = empl.Name;
                this.LoginTB.Text = empl.Login;
                this.PositionTB.Text = empl.Position;
                this.PasswordTB.Text = empl.Password;
                this.WagesTB.Text = empl.Wages.ToString();
                this.IsAdminCB.IsChecked = empl.IsAdmin;
            }

            this.empl = empl;
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employee empl;
            if (this.empl == null) empl = new Employee();
            else empl = this.empl;

            empl.Name = this.NameTB.Text;
            empl.Login = this.LoginTB.Text;
            empl.Position = this.PositionTB.Text;
            empl.Password = this.PasswordTB.Text;
            empl.IsAdmin = (bool)this.IsAdminCB.IsChecked;

            if (int.TryParse(this.WagesTB.Text, out int wages) &&
                this.NameTB.Text.Replace(" ", "") != "" &&
                this.LoginTB.Text.Replace(" ", "") != "" &&
                this.PositionTB.Text.Replace(" ", "") != "" &&
                this.PasswordTB.Text.Replace(" ", "") != "") empl.Wages = wages;
            else
            {
                MessageBox.Show(
                    "Неверный формат данных",
                    "Data format Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            using (var context = new HostelContext())
            {
                context.Employees.AddOrUpdate(empl);
                context.SaveChanges();
            }

            this.Close();


        }
    }
}
