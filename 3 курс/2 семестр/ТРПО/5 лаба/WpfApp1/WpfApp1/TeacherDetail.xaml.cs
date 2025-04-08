using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
	/// Логика взаимодействия для TeacherDetail.xaml
	/// </summary>
	public partial class TeacherDetail : Window
	{
		public Teacher teacher;
		CuratorsEntities db;

		public TeacherDetail(Teacher teacher)
		{
			this.teacher = teacher;
			this.db = CuratorsEntities.GetContext();
			InitializeComponent();

			UpdateData();
		}

		public void UpdateData()
		{
			Name.Text = $"{teacher.FirstName} {teacher.LastName}";
			Subject.Text = teacher.Subject;
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
				teacher.FirstName = new_value.Split(' ')[0];
				teacher.LastName = new_value.Split(' ')[1];
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' должно состоять из двух слов: Имя Фамилия, разделенных пробелом");

			UpdateData();
		}

		private void EditSubject(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите название предмета одной строкой");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			if (new_value.Length != 0)
			{
				teacher.Subject = new_value;
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! Пустое значение");

			UpdateData();
		}
	}
}
