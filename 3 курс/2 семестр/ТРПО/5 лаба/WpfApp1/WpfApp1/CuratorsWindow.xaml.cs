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
	/// Логика взаимодействия для CuratorsWindow.xaml
	/// </summary>
	public partial class CuratorsWindow : Window
	{
		public CuratorsWindow()
		{
			InitializeComponent();
			ShowData();
		}

		public void ShowData()
		{
			var db = CuratorsEntities.GetContext();
			List<Curator> curators = db.Curator.ToList();
			if (curators.Count == 0) this.CardsList.Children.Clear();
			else if (curators.Count > 1)
			{
				for (int i = 1; i < curators.Count; i++)
				{
					WrapPanel el = XamlReader.Parse(
						XamlWriter.Save(
							this.UserCard0
							)
						) as WrapPanel;

					this.RegisterName($"UserCard{i}", el);
					this.CardsList.Children.Add(el);
				}
			}

			for (int i = 0; i < curators.Count; i++)
			{
				var curator = curators[i];
				int TBCounter = 0;
				int ICounter = 0;

				Canvas container = (this.FindName($"UserCard{i}") as WrapPanel).Children[0] as Canvas;

				foreach (UIElement el in container.Children)
				{
					string val = "";
					if (el.GetType().ToString() == "System.Windows.Controls.TextBlock")
					{
						if (TBCounter == 0) val = $"{curator.FirstName} {curator.LastName}";
						else if (TBCounter == 1) val = curator.Email;
						else if (TBCounter == 2) val = curator.CellPhone;

						el.SetValue(TextBlock.TextProperty, val);
						TBCounter++;
					}
					if (el.GetType().ToString() == "System.Windows.Controls.Image")
					{
						if (ICounter == 1)
						{
							el.MouseUp += (o, e) =>
							{
								var win = new CuratorDetail(curator);
								win.Show();
								this.Close();
							};
						}
						else if (ICounter == 2)
						{
							el.MouseUp += (o, e) =>
							{
								int count_students = db.Student.Where(s => s.CuratorId == curator.CuratorID).ToList().Count;
								if (count_students == 0)
								{
									db.Curator.Remove(curator);
									db.SaveChanges();

									var win = new CuratorsWindow();
									win.Show();
									this.Close();
								} else
								{
									MessageBox.Show("Ошибка! Вы не можете удалить куратора, пока к нему привязаны студенты");
								}
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

		private void CreateCurator(object sender, RoutedEventArgs e)
		{
			var db = CuratorsEntities.GetContext();
			Curator curator = new Curator()
			{
				FirstName = "__________",
				LastName = "__________",
				CellPhone = "+78917264893",
				Email = "__.__.____",
			};
			db.Curator.Add(curator);
			db.SaveChanges();

			var win = new CuratorDetail(curator);
			win.Show();
			this.Close();
		}
	}
}
