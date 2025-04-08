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

namespace РПМ_ЛБ_3_2_2
{
	/// <summary>
	/// Логика взаимодействия для UserControl1.xaml
	/// </summary>
	public partial class UserControl1 : UserControl
	{
		public UserControl1()
		{
			InitializeComponent();
		}
		public static readonly DependencyProperty ImageSourceProperty =
		   DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(UserControl), new PropertyMetadata(null));

		public ImageSource ImageSource
		{
			get { return (ImageSource)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value); }
		}
	}
}
