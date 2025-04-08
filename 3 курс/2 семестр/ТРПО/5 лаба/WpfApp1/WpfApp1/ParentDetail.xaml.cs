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
	/// Логика взаимодействия для ParentDetail.xaml
	/// </summary>
	public partial class ParentDetail : Window
	{
		public Parent parent;
		CuratorsEntities db;

		public ParentDetail(Parent parent)
		{
			this.parent = parent;
			this.db = CuratorsEntities.GetContext();
			InitializeComponent();

			UpdateData();

		}

		public void UpdateData()
		{
			Name.Text = $"{parent.FirstName} {parent.LastName}";
			Phone.Text = parent.CellPhone;
			Email.Text = parent.Email;
			Workplace.Text = parent.Workplace;
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
				parent.FirstName = new_value.Split(' ')[0];
				parent.LastName = new_value.Split(' ')[1];
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
				parent.CellPhone = new_value;
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
				parent.Email = new_value.ToString();
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' не подходит под требования к формату почты");

			UpdateData();
		}

		private void EditWorkplace(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите название места работы родителя");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			if (new_value.Length > 0)
			{
				parent.Workplace = new_value;
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка!");

			UpdateData();
		}
	}
}
