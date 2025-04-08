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
	/// Логика взаимодействия для UsersWindow.xaml
	/// </summary>
	public partial class UsersWindow : Window
	{
		public UsersWindow()
		{
			InitializeComponent();

			ShowData();
		}

		public void ShowData()
		{
			var db = CuratorsEntities.GetContext();
			List<Student> students = db.Student.ToList();

			if (students.Count == 0) this.CardsList.Children.Clear();
			else if (students.Count > 1)
			{
				for (int i = 1; i < students.Count; i++)
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

			for (int i = 0; i < students.Count; i++)
			{
				var student = students[i];
				int TBCounter = 0;
				int ICounter = 0;

				Canvas container = (this.FindName($"UserCard{i}") as WrapPanel).Children[0] as Canvas;

				foreach (UIElement el in container.Children)
				{
					string val = "";
					if (el.GetType().ToString() == "System.Windows.Controls.TextBlock")
					{
						if (TBCounter == 0) val = $"{student.FirstName} {student.LastName}";
						else if (TBCounter == 1) val = student.GroupNumber;
						else if (TBCounter == 2) val = student.BDate;
						else if (TBCounter == 3) val = student.CellPhone;
						else if (TBCounter == 4)
						{
							Curator curator = db.Curator.FirstOrDefault(c => c.CuratorID == student.CuratorId);
							val = $"Куратор: {curator.FirstName} {curator.LastName}";
						}

						el.SetValue(TextBlock.TextProperty, val);
						TBCounter++;
					}
					if (el.GetType().ToString() == "System.Windows.Controls.Image")
					{
						if (ICounter == 1)
						{
							el.MouseUp += (o, e) =>
							{
								var win = new UserDetail(student);
								win.Show();
								this.Close();
							};
						}
						else if (ICounter == 2)
						{
							el.MouseUp += (o, e) =>
							{
								db.Student.Remove(student);
								db.SaveChanges();

								var win = new UsersWindow();
								win.Show();
								this.Close();
								//ShowData();
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

		private void CreateUser(object sender, RoutedEventArgs e)
		{
			var db = CuratorsEntities.GetContext();
			Student student = new Student()
			{
				FirstName = "__________",
				LastName = "__________",
				CellPhone = "+78917264893",
				BDate = "__.__.____",
				GroupNumber = "____",
				CuratorId = db.Curator.First().CuratorID
			};
			db.Student.Add(student);
			db.SaveChanges();

			var win = new UserDetail(student);
			win.Show();
			this.Close();
		}
	}
}
