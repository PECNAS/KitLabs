using ClosedXML.Excel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Base;
using WpfApp1.Templates;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BtnsEnabledChange(false);
            var loadingWidget = new DBLoading();
            this.WidgetPlace.Children.Add(loadingWidget);
            if (!loadingWidget.ConnectionCheck())
            {
                MessageBox.Show("Ошибка подключения к бд!");
            } else
            {
                this.WidgetPlace.Children.Clear();
                this.WidgetPlace.Children.Add(new AuthWidget(this));
            }
        }


        public void BtnsEnabledChange(bool flag)
        {
            this.StudentsBtn.IsEnabled = flag;
            this.CarsBtn.IsEnabled = flag;
            this.TicketsBtn.IsEnabled = flag;
            this.InstructorsBtn.IsEnabled = flag;
        }

        private void StudentsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new StudentsWidget(this));
        }

        private void InstructorsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new InstructorsWidget(this));
        }

        private void TicketsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new TicketsWidget(this));
        }

        private void CarsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WidgetPlace.Children.Clear();
            this.WidgetPlace.Children.Add(new CarsWidget(this));
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new SchoolContext())
            {
                var instructors = context.Instructors.ToList();
                var students = context.Students.ToList();
                var cars = context.Cars.ToList();
                var tickets = context.Tickets.ToList();

                // Создание нового файла Excel
                var workbook = new XLWorkbook();
                var studentsWs = workbook.Worksheets.Add("Ученики");
                var instructorsWs = workbook.Worksheets.Add("Инструктора");
                var ticketsWs = workbook.Worksheets.Add("Билеты");
                var carsWs = workbook.Worksheets.Add("Машины");

                // Добавление заголовков
                studentsWs.Cell(1, 1).Value = "ID";
                studentsWs.Cell(1, 2).Value = "Email";
                studentsWs.Cell(1, 3).Value = "Имя";
                studentsWs.Cell(1, 4).Value = "Начало обучения";
                studentsWs.Cell(1, 5).Value = "Конец обучения";
                studentsWs.Cell(1, 6).Value = "Инструктор";
                studentsWs.Cell(1, 7).Value = "Категория обучения";

                instructorsWs.Cell(1, 1).Value = "ID";
                instructorsWs.Cell(1, 2).Value = "Email";
                instructorsWs.Cell(1, 3).Value = "Имя";
                instructorsWs.Cell(1, 4).Value = "Роль";
                instructorsWs.Cell(1, 5).Value = "Категория";
                instructorsWs.Cell(1, 6).Value = "Машина";

                ticketsWs.Cell(1, 1).Value = "ID";
                ticketsWs.Cell(1, 2).Value = "Вопрос";
                ticketsWs.Cell(1, 3).Value = "Картинка";
                ticketsWs.Cell(1, 4).Value = "Ответ #1";
                ticketsWs.Cell(1, 5).Value = "Ответ #2";
                ticketsWs.Cell(1, 6).Value = "Ответ #3";
                ticketsWs.Cell(1, 7).Value = "Правильный ответ";

                carsWs.Cell(1, 1).Value = "ID";
                carsWs.Cell(1, 2).Value = "Название";
                carsWs.Cell(1, 3).Value = "Категория";
                carsWs.Cell(1, 4).Value = "Картинка";

                for (int i = 0; i < students.Count; i++)
                {
                    studentsWs.Cell(i + 2, 1).Value = students[i].Id;
                    studentsWs.Cell(i + 2, 2).Value = students[i].Email;
                    studentsWs.Cell(i + 2, 3).Value = students[i].Name;
                    studentsWs.Cell(i + 2, 4).Value = students[i].StartDate;
                    studentsWs.Cell(i + 2, 5).Value = students[i].EndDate;

                    if (students[i].Instructor != null) studentsWs.Cell(i + 2, 6).Value = students[i].Instructor.Name;
                    else studentsWs.Cell(i + 2, 6).Value = "Не выбран";

                    studentsWs.Cell(i + 2, 7).Value = students[i].Category;
                }

                for (int i = 0; i < instructors.Count; i++)
                {
                    instructorsWs.Cell(i + 2, 1).Value = instructors[i].Id;
                    instructorsWs.Cell(i + 2, 2).Value = instructors[i].Email;
                    instructorsWs.Cell(i + 2, 3).Value = instructors[i].Name;
                    instructorsWs.Cell(i + 2, 4).Value = instructors[i].Role;
                    instructorsWs.Cell(i + 2, 5).Value = instructors[i].Category;

                    if (instructors[i].Car != null) instructorsWs.Cell(i + 2, 6).Value = instructors[i].Car.Name;
                    else instructorsWs.Cell(i + 2, 6).Value = "Не указано";
                }

                for (int i = 0; i < cars.Count; i++)
                {
                    carsWs.Cell(i + 2, 1).Value = cars[i].Id;
                    carsWs.Cell(i + 2, 2).Value = cars[i].Name;
                    carsWs.Cell(i + 2, 3).Value = cars[i].Category;
                    carsWs.Cell(i + 2, 4).Value = cars[i].Image;
                }

                for (int i = 0; i < tickets.Count; i++)
                {
                    ticketsWs.Cell(i + 2, 1).Value = tickets[i].Id;
                    ticketsWs.Cell(i + 2, 2).Value = tickets[i].TicketQuest;
                    ticketsWs.Cell(i + 2, 3).Value = tickets[i].Image;
                    ticketsWs.Cell(i + 2, 4).Value = tickets[i].Answer1;
                    ticketsWs.Cell(i + 2, 5).Value = tickets[i].Answer2;
                    ticketsWs.Cell(i + 2, 6).Value = tickets[i].Answer3;
                    ticketsWs.Cell(i + 2, 7).Value = tickets[i].TrueAnswer;
                }

                // Сохранение файла на диск
                var filePath = "C:\\File.xlsx";
                workbook.SaveAs(filePath);

                MessageBox.Show($"Файл сохранён по пути: {filePath}");
            }

        }
    }
}