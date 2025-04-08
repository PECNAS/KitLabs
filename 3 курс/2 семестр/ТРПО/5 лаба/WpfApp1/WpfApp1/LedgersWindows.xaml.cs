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
	/// Логика взаимодействия для LedgersWindows.xaml
	/// </summary>
	public partial class LedgersWindows : Window
	{
		public LedgersWindows()
		{
			InitializeComponent();
			ShowData();
		}

		public void ShowData()
		{
			var db = CuratorsEntities.GetContext();
			List<SummaryLedger> ledgers = db.SummaryLedger.ToList();

			if (ledgers.Count == 0) this.CardsList.Children.Clear();
			else if (ledgers.Count > 1)
			{
				for (int i = 1; i < ledgers.Count; i++)
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

			for (int i = 0; i < ledgers.Count; i++)
			{
				var ledger = ledgers[i];
				int TBCounter = 0;
				int ICounter = 0;

				Canvas container = (this.FindName($"UserCard{i}") as WrapPanel).Children[0] as Canvas;

				foreach (UIElement el in container.Children)
				{
					string val = "";
					if (el.GetType().ToString() == "System.Windows.Controls.TextBlock")
					{
						Student student = db.Student.FirstOrDefault(s => s.StudentId == ledger.StudentId);
						Teacher teacher = db.Teacher.FirstOrDefault(t => t.TeacherId == ledger.TeacherId);

						if (TBCounter == 0) val = $"{student.FirstName} {student.LastName}";
						else if (TBCounter == 1) val = $"{teacher.FirstName} {teacher.LastName}";
						else if (TBCounter == 2) val = teacher.Subject;
						else if (TBCounter == 3) val = $"{ledger.Semester} | {ledger.Grade}";

						el.SetValue(TextBlock.TextProperty, val);
						TBCounter++;
					}
					if (el.GetType().ToString() == "System.Windows.Controls.Image")
					{
						if (ICounter == 0)
						{
							el.MouseUp += (o, e) =>
							{
								var win = new LedgerDetail(ledger);
								win.Show();
								this.Close();
							};
						}
						else if (ICounter == 1)
						{
							el.MouseUp += (o, e) =>
							{
								db.SummaryLedger.Remove(ledger);
								db.SaveChanges();

								var win = new LedgersWindows();
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

		private void CreateLedger(object sender, RoutedEventArgs e)
		{
			var db = CuratorsEntities.GetContext();
			SummaryLedger ledger = new SummaryLedger()
			{
				Grade = "0",
				Semester = 0,
				TeacherId = db.Teacher.First().TeacherId,
				StudentId = db.Student.First().StudentId,
			};
			db.SummaryLedger.Add(ledger);
			db.SaveChanges();

			var win = new LedgerDetail(ledger);
			win.Show();
			this.Close();
		}
	}
}
