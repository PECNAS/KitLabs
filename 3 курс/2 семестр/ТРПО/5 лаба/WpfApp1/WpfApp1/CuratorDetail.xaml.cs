using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Логика взаимодействия для CuratorDetail.xaml
	/// </summary>
	public partial class CuratorDetail : Window
	{
		public Curator curator;
		CuratorsEntities db;

		public CuratorDetail(Curator curator)
		{
			this.curator = curator;
			this.db = CuratorsEntities.GetContext();
			InitializeComponent();

			UpdateData();

		}

		public void UpdateData()
		{
			Name.Text = $"{this.curator.FirstName} {this.curator.LastName}";
			Phone.Text = this.curator.CellPhone;
			Email.Text = this.curator.Email;
		}

		private void OpenCurators(object sender, RoutedEventArgs e)
		{
			(new CuratorsWindow()).Show();
			this.Close();
		}

		private void OpenStudents(object sender, RoutedEventArgs e)
		{
			(new UsersWindow()).Show();
			this.Close();
		}

		private void OpenParents(object sender, RoutedEventArgs e)
		{
			(new ParentsWindow()).Show();
			this.Close();
		}

		private void OpenTeachers(object sender, RoutedEventArgs e)
		{
			(new TeachersWindow()).Show();
			this.Close();
		}

		private void EditName(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите данные в формате Имя Фамилия");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			if (new_value.Length != 0 && new_value.Split(' ').Length == 2)
			{
				curator.FirstName = new_value.Split(' ')[0];
				curator.LastName = new_value.Split(' ')[1];
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' должно состоять из двух слов: Имя Фамилия, разделенных пробелом");

			UpdateData();
		}

		private void EditPhone(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите номер телефона в формате +71231231231");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;
			if (new_value.StartsWith("+7") && new_value.Length == 12 && long.TryParse(new_value.Replace("+", ""), out _))
			{
				curator.CellPhone = new_value;
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' должен начинаться с +7 и состоять из 11 цифр");

			UpdateData();
		}

		private void EditEmail(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите электронную почту в формате test@test.test");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;
			if (new_value.Contains("@") && new_value.Contains("."))
			{
				curator.Email = new_value.ToString();
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' не подходит под требования к формату данных");

			UpdateData();
		}
	}
}