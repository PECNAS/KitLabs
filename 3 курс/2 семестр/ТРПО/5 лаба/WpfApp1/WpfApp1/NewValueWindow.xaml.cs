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

namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для NewValueWindow.xaml
	/// </summary>
	public partial class NewValueWindow : Window
	{
		public string new_value;
		public NewValueWindow(string desc)
		{
			InitializeComponent();
			this.Description.Text = desc;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			new_value = this.ValueTB.Text;
			this.Close();
		}
	}
}
