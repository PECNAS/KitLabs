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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для TeachersWindow.xaml
	/// </summary>
	public partial class TeachersWindow : Window
	{
		public TeachersWindow()
		{
			InitializeComponent();
			ShowData();
		}

		public void ShowData()
		{
			var db = CuratorsEntities.GetContext();
			List<Teacher> teachers = db.Teacher.ToList();

			if (teachers.Count == 0) this.CardsList.Children.Clear();
			else if (teachers.Count > 1)
			{
				for (int i = 1; i < teachers.Count; i++)
				{
					WrapPanel el = XamlReader.Parse(
						XamlWriter.Save(
							this.UserCard0
							)
						) as WrapPanel;

					//el.SetValue(Grid.ColumnProperty, i % 3);
					//el.SetValue(Grid.RowProperty, i / 3);
					this.RegisterName($"UserCard{i}", el);
					this.CardsList.Children.Add(el);
				}
			}

			for (int i = 0; i < teachers.Count; i++)
			{
				var teacher = teachers[i];
				int TBCounter = 0;
				int ICounter = 0;

				Canvas container = (this.FindName($"UserCard{i}") as WrapPanel).Children[0] as Canvas;

				foreach (UIElement el in container.Children)
				{
					string val = "";
					if (el.GetType().ToString() == "System.Windows.Controls.TextBlock")
					{
						if (TBCounter == 0) val = $"{teacher.FirstName} {teacher.LastName}";
						else if (TBCounter == 1) val = teacher.Subject;

						el.SetValue(TextBlock.TextProperty, val);
						TBCounter++;
					}
					if (el.GetType().ToString() == "System.Windows.Controls.Image")
					{
						if (ICounter == 1)
						{
							el.MouseUp += (o, e) =>
							{
								var win = new TeacherDetail(teacher);
								win.Show();
								this.Close();
							};
						}
						else if (ICounter == 2)
						{
							el.MouseUp += (o, e) =>
							{
								db.Teacher.Remove(teacher);
								db.SaveChanges();

								var win = new TeachersWindow();
								win.Show();
								this.Close();
							};
						}


						ICounter++;
					}
				}
			}
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

		private void CreateTeacher(object sender, RoutedEventArgs e)
		{
			var db = CuratorsEntities.GetContext();
			Teacher teacher = new Teacher()
			{
				FirstName = "__________",
				LastName = "__________",
				Subject = "_____"
			};
			db.Teacher.Add(teacher);
			db.SaveChanges();

			var win = new TeacherDetail(teacher);
			win.Show();
			this.Close();
		}
	}
}
