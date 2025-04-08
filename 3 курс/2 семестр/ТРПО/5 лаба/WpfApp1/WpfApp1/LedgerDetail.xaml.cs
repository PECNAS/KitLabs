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
	/// Логика взаимодействия для LedgerDetail.xaml
	/// </summary>
	public partial class LedgerDetail : Window
	{
		public SummaryLedger ledger;
		public Student student;
		public Teacher teacher;
		CuratorsEntities db;

		public LedgerDetail(SummaryLedger ledger)
		{
			this.ledger = ledger;
			this.db = CuratorsEntities.GetContext();
			this.student = db.Student.FirstOrDefault(s => s.StudentId == ledger.StudentId);
			this.teacher = db.Teacher.FirstOrDefault(t => t.TeacherId == ledger.TeacherId);
			InitializeComponent();

			UpdateData();

		}

		public void UpdateData()
		{
			this.StudentName.Text = $"{student.FirstName} {student.LastName}";
			this.TeacherName.Text = $"{teacher.FirstName} {teacher.LastName}";
			this.SubjectName.Text = teacher.Subject;
			this.Semester.Text = ledger.Semester.ToString();
			this.Grade.Text = ledger.Grade.ToString();
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

		private void OpenLedgers(object sender, RoutedEventArgs e)
		{
			(new LedgersWindows()).Show();
			this.Close();
		}

		private void EditStudent(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите уникальный идентификатор студента");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			if (int.TryParse(new_value, out int st_id))
			{
				Student student = db.Student.FirstOrDefault(s => s.StudentId == st_id);
				if (student != null)
				{
					ledger.StudentId = st_id;
					db.SaveChanges();
					MessageBox.Show("Новые данные успешно сохранены");
				}
				else MessageBox.Show($"Ошибка! Студента с Id {st_id} не существует!");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' должно быть целым числом");

			UpdateData();
		}

		private void EditTeacher(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите уникальный идентификатор преподавателя");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			if (int.TryParse(new_value, out int teacher_id))
			{
				Teacher teacher = db.Teacher.FirstOrDefault(t => t.TeacherId == teacher_id);
				if (teacher != null)
				{
					ledger.TeacherId = teacher_id;
					db.SaveChanges();
					MessageBox.Show("Новые данные успешно сохранены");
				}
				else MessageBox.Show($"Ошибка! Преподавателя с Id {teacher_id} не существует!");
			}
			else MessageBox.Show($"Ошибка! '{new_value}' должно быть целым числом");

			UpdateData();
		}

		private void EditSemester(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите семестр обучения одним числом");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			if (int.TryParse(new_value, out int semester) && semester > 0)
			{
				ledger.Semester = semester;
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! Данные должны быть целым числом");

			UpdateData();
		}

		private void EditGrade(object sender, RoutedEventArgs e)
		{
			var win = new NewValueWindow("Введите оценку за предмет");
			win.ShowDialog();
			string new_value = win.new_value;
			if (new_value == null) return;

			if (int.TryParse(new_value, out int grade))
			{
				ledger.Grade = grade.ToString();
				db.SaveChanges();
				MessageBox.Show("Новые данные успешно сохранены");
			}
			else MessageBox.Show($"Ошибка! Данные должны быть целым числом");

			UpdateData();
		}
	}
}
