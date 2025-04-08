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
	/// Логика взаимодействия для ParentsWindow.xaml
	/// </summary>
	public partial class ParentsWindow : Window
	{
		public ParentsWindow()
		{
			InitializeComponent();
			ShowData();
		}

		public void ShowData()
		{
			var db = CuratorsEntities.GetContext();
			List<Parent> parents = db.Parent.ToList();

			if (parents.Count == 0) this.CardsList.Children.Clear();
			else if (parents.Count > 1)
			{
				for (int i = 1; i < parents.Count; i++)
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

			for (int i = 0; i < parents.Count; i++)
			{
				var parent = parents[i];
				int TBCounter = 0;
				int ICounter = 0;

				Canvas container = (this.FindName($"UserCard{i}") as WrapPanel).Children[0] as Canvas;

				foreach (UIElement el in container.Children)
				{
					string val = "";
					if (el.GetType().ToString() == "System.Windows.Controls.TextBlock")
					{
						if (TBCounter == 0) val = $"{parent.FirstName} {parent.LastName}";
						else if (TBCounter == 1) val = parent.CellPhone;
						else if (TBCounter == 2) val = parent.Email;
						else if (TBCounter == 3) val = $"Место работы: {parent.Workplace}";

						el.SetValue(TextBlock.TextProperty, val);
						TBCounter++;
					}
					if (el.GetType().ToString() == "System.Windows.Controls.Image")
					{
						if (ICounter == 1)
						{
							el.MouseUp += (o, e) =>
							{
								var win = new ParentDetail(parent);
								win.Show();
								this.Close();
							};
						}
						else if (ICounter == 2)
						{
							el.MouseUp += (o, e) =>
							{
								db.Parent.Remove(parent);
								db.SaveChanges();

								var win = new ParentsWindow();
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

		private void CreateParent(object sender, RoutedEventArgs e)
		{
			var db = CuratorsEntities.GetContext();
			Parent parent = new Parent()
			{
				FirstName = "__________",
				LastName = "__________",
				CellPhone = "+7__________",
				Email = "___@___.__",
				Workplace = "_____"
			};
			db.Parent.Add(parent);
			db.SaveChanges();

			var win = new ParentDetail(parent);
			win.Show();
			this.Close();
		}
	}
}

