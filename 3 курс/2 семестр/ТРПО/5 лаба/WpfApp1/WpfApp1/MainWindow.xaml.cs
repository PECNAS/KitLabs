using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//var win = new UsersWindow();
			//win.Show();
			//
			//var win = new CuratorsWindow();
			//win.Show();
			//
			//var win = new ParentsWindow();
			//win.Show();
			//
			//var win = new TeachersWindow();
			//win.Show();
			//var win = new Window1();
			//win.Show();
			
		}

		private void AuthenticateUser(object sender, EventArgs e)
		{
			string login = this.Login.Text;
			string psswd = this.Password.Text;

			if (login == "admin" && psswd == "admin")
			{
				(new UsersWindow()).Show();
				this.Close();
			}
		}
	}
}
