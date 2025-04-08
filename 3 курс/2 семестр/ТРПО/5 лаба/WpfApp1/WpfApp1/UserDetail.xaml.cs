using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
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
	/// Логика взаимодействия для UserDetail.xaml
	/// </summary>
	public partial class UserDetail : Window
	{
		public Student student;
		CuratorsEntities db;

		public UserDetail(Student student)
		{
			this.student = student;
			this.db = CuratorsEntities.GetContext();
			InitializeComponent();

			UpdateData();

		}

		public void UpdateData()
		{
			Name.Text = $"{student.FirstName} {student.LastName}";
			Phone.Text = student.CellPhone;
			Group.Text = student.GroupNumber;
			BDate.Text = student.BDate;

			var parents_list = db.Student_Parent_Relationship.Where(spr => spr.StudentId == student.StudentId);
			string parents = "";

			foreach (var spr in parents_list)
			{
				var parent = db.Parent.FirstOrDefault(p => p.ParentId == spr.ParentId);
				parents += $"{parent.FirstName} {parent.LastName}, ";
			}
			this.Parent.Text = parents;

			Curator curator = db.Curator.FirstOrDefault(c => c.CuratorID == student.CuratorId);
			Curator.Text = $"{curator.FirstName} {curator.LastName}";
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
				student.FirstName = new_value.Split(' ')[0];
				student.LastName = new_value.Split(' ')[1];
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
				student.CellPhone = new_value;
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' должен начинаться с +7 и состоять из 11 цифр");

			UpdateData();
		}

		private void EditBDate(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите дату рождения в формате дд.мм.гггг");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;
			if (DateTime.TryParse(new_value, out DateTime date))
			{
				student.BDate = new_value.ToString();
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' не подходит под требования к формату данных");

			UpdateData();
		}

		private void EditGroup(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите группу числом из четырех цифр");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			if (new_value.Length == 4 && int.TryParse(new_value, out int group) && group > 0)
			{
				student.GroupNumber = new_value;
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! Группа '{new_value}' должна состоять из четырех цифр. Пример: 4338");

			UpdateData();
		}

		private void EditCurator(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите уникальный идентификатор куратора (одно целое число)");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			string fname = new_value.Split(' ')[0];
			string lname = new_value.Split(' ')[1];

			if (new_value.Split(' ').Length == 2)
			{
				Curator curator = db.Curator.FirstOrDefault(
					c => c.LastName == lname &&
					c.FirstName == fname);
				if (curator != null)
				{
					student.CuratorId = curator.CuratorID;
					db.SaveChanges();
					MessageBox.Show("Новые данные успешно сохранены");
				}
				else MessageBox.Show($"Ошибка! Куратор с именем {new_value.Split(' ')[0]} и фамилией {new_value.Split(' ')[1]} не найден!");
			}
			else MessageBox.Show($"Ошибка! Введите имя и фамилию куратора через пробел");

			UpdateData();
		}

		private void EditParent(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите уникальные идентификаторы родителей через пробел");
			win.ShowDialog();
			string new_value = win.new_value;
			var ids = new_value.Split(' ');
			if (ids.Length == 2 || ids.Length == 1)
			{
				if (int.TryParse(ids[0], out int id1) && int.TryParse(ids[1], out int id2))
				{
					var parents = db.Student_Parent_Relationship.Where(spr => spr.StudentId == id1);
					foreach (Student_Parent_Relationship parent in parents) db.Student_Parent_Relationship.Remove(parent);
					db.SaveChanges();

					db.Student_Parent_Relationship.Add( new Student_Parent_Relationship()
					{
						StudentId = student.StudentId,
						ParentId = id1
					});
					db.Student_Parent_Relationship.Add(new Student_Parent_Relationship()
					{
						StudentId = student.StudentId,
						ParentId = id2
					});

					db.SaveChanges();
				}
				else MessageBox.Show("Ошибка! Введены не числовые значения");
			}
			else MessageBox.Show("Ошибка! Введите 1 или 2 идентификатора");

			UpdateData();
		}
	}
}
