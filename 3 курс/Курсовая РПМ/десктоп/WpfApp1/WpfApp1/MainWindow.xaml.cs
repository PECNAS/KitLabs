using ClosedXML.Excel;
using Microsoft.Win32;
using System.Data.Entity.Core.Mapping;
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
using WpfApp1.Templates.Widgets;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EmployeesWidget employeesWidget = null;
        public ReservesWidget reservesWidget = null;
        public RoomsWidget roomsWidget = null;
        public VisitorsWidget visitorsWidget = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.TitleTBlock.Text = "Авторизация";

            var loadingWidget = new DBLoading();
            this.WidgetPlace.Children.Add(loadingWidget);
            if (!loadingWidget.ConnectionCheck())
            {
                MessageBox.Show("Ошибка подключения к бд!");
            }
            else
            {
                this.WidgetPlace.Children.Clear();
                this.WidgetPlace.Children.Add(new AuthWidget(this));
            }
        }

        private void ReservesBtn_Click(object sender, RoutedEventArgs e)
        {
            this.TitleTBlock.Text = "Бронирования";
            this.WidgetPlace.Children.Clear();

            this.employeesWidget = null;
            this.reservesWidget = new ReservesWidget(this);
            this.roomsWidget = null;
            this.visitorsWidget = null;

            this.WidgetPlace.Children.Add(this.reservesWidget);
        }

        private void VisitorsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.TitleTBlock.Text = "Посетители";
            this.WidgetPlace.Children.Clear();

            employeesWidget = null;
            reservesWidget = null;
            roomsWidget = null;
            visitorsWidget = new VisitorsWidget(this);

            this.WidgetPlace.Children.Add(this.visitorsWidget);
        }

        private void RoomsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.TitleTBlock.Text = "Комнаты";
            this.WidgetPlace.Children.Clear();

            employeesWidget = null;
            reservesWidget = null;
            roomsWidget = new RoomsWidget(this);
            visitorsWidget = null;

            this.WidgetPlace.Children.Add(this.roomsWidget);
        }

        private void EmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            this.TitleTBlock.Text = "Сотрудники";
            this.WidgetPlace.Children.Clear();

            employeesWidget = new EmployeesWidget(this);
            reservesWidget = null;
            roomsWidget = null;
            visitorsWidget = null;

            this.WidgetPlace.Children.Add(this.employeesWidget);
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new HostelContext())
            {
                var empls = context.Employees.ToList();
                var visitors = context.Visitors.ToList();
                var reserves = context.Reserves.ToList();
                var rooms = context.Rooms.ToList();

                // Создание нового файла Excel
                var workbook = new XLWorkbook();
                var emplsWs = workbook.Worksheets.Add("Сотрудники");
                var visitorsWs = workbook.Worksheets.Add("Посетители");
                var roomWs = workbook.Worksheets.Add("Номера");
                var reservesWs = workbook.Worksheets.Add("Брони");

                // Добавление заголовков
                emplsWs.Cell(1, 1).Value = "Id";
                emplsWs.Cell(1, 2).Value = "Администратор";
                emplsWs.Cell(1, 3).Value = "Логин";
                emplsWs.Cell(1, 4).Value = "Имя";
                emplsWs.Cell(1, 5).Value = "Должность";
                emplsWs.Cell(1, 6).Value = "Зарплата";

                visitorsWs.Cell(1, 1).Value = "Id";
                visitorsWs.Cell(1, 2).Value = "Имя";
                visitorsWs.Cell(1, 3).Value = "Номер телефона";
                visitorsWs.Cell(1, 4).Value = "Количество бронирований";

                roomWs.Cell(1, 1).Value = "Id";
                roomWs.Cell(1, 2).Value = "Номер комнаты";
                roomWs.Cell(1, 3).Value = "Тип номер";
                roomWs.Cell(1, 4).Value = "Цена";
                roomWs.Cell(1, 5).Value = "Описание";
                roomWs.Cell(1, 6).Value = "Свободна";
                roomWs.Cell(1, 7).Value = "Бронь";

                reservesWs.Cell(1, 1).Value = "Id";
                reservesWs.Cell(1, 2).Value = "Заезд";
                reservesWs.Cell(1, 3).Value = "Выезд";
                reservesWs.Cell(1, 4).Value = "Номер";
                reservesWs.Cell(1, 5).Value = "Посетитель";

                for (int i = 0; i < empls.Count; i++)
                {
                    emplsWs.Cell(i + 2, 1).Value = empls[i].Id;
                    emplsWs.Cell(i + 2, 2).Value = empls[i].IsAdmin;
                    emplsWs.Cell(i + 2, 3).Value = empls[i].Login;
                    emplsWs.Cell(i + 2, 4).Value = empls[i].Name;
                    emplsWs.Cell(i + 2, 5).Value = empls[i].Position;
                    emplsWs.Cell(i + 2, 6).Value = empls[i].Wages;
                }

                for (int i = 0; i < visitors.Count; i++)
                {
                    visitorsWs.Cell(i + 2, 1).Value = visitors[i].Id;
                    visitorsWs.Cell(i + 2, 2).Value = visitors[i].Name;
                    visitorsWs.Cell(i + 2, 3).Value = visitors[i].PhoneNumber;
                    if (visitors[i].Reserves != null)
                        visitorsWs.Cell(i + 2, 4).Value = visitors[i].Reserves.Count;
                }

                for (int i = 0; i < rooms.Count; i++)
                {
                    roomWs.Cell(i + 2, 1).Value = rooms[i].Id; //"Id";
                    roomWs.Cell(i + 2, 2).Value = rooms[i].RoomNumber; //"Номер комнаты";
                    roomWs.Cell(i + 2, 3).Value = rooms[i].RoomType; //"Тип номер";
                    roomWs.Cell(i + 2, 4).Value = rooms[i].Price; //"Цена";
                    roomWs.Cell(i + 2, 5).Value = rooms[i].Description; //"Описание";
                    roomWs.Cell(i + 2, 6).Value = rooms[i].IsFree; //"Свободна";
                    if (rooms[i].Reserve != null)
                        roomWs.Cell(i + 2, 7).Value = rooms[i].Reserve.StartDate; //"Бронь";
                }

                for (int i = 0; i < reserves.Count; i++)
                {
                    reservesWs.Cell(i + 2, 1).Value = reserves[i].Id; //"Id";
                    reservesWs.Cell(i + 2, 2).Value = reserves[i].StartDate; //"Заезд";
                    reservesWs.Cell(i + 2, 3).Value = reserves[i].EndDate; //"Выезд";
                    if (reserves[i].Room != null && reserves[i].Visitor != null)
                        reservesWs.Cell(i + 2, 4).Value = reserves[i].Room.RoomNumber; //"Номер";
                    reservesWs.Cell(i + 2, 5).Value = reserves[i].Visitor.Name; //"Посетитель";
                }

                // Сохранение файла на диск
                try
                {

                    var ofd = new OpenFolderDialog();
                    bool? result = ofd.ShowDialog();
                    workbook.SaveAs($"{ofd.FolderName}\\FullReport.xlsx");
                    MessageBox.Show(
                        $"Файл сохранён по пути: {ofd.FolderName}",
                        "File Saved",
                        MessageBoxButton.OK,
                        MessageBoxImage.Asterisk);
                }
                catch (Exception ex)
                {
                    return;
                }
            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (employeesWidget != null) employeesWidget.DeleteEntity();
            else if (roomsWidget != null) roomsWidget.DeleteEntity();
            else if (reservesWidget != null) reservesWidget.DeleteEntity();
            else if (visitorsWidget != null) visitorsWidget.DeleteEntity();
        }

        private void UpdateDtn_Click(object sender, RoutedEventArgs e)
        {
            if (employeesWidget != null) employeesWidget.UpdateEntity();
            else if (roomsWidget != null) roomsWidget.UpdateEntity();
            else if (reservesWidget != null) reservesWidget.UpdateEntity();
            else if (visitorsWidget != null) visitorsWidget.UpdateEntity();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (employeesWidget != null) employeesWidget.AddEntity();
            else if (roomsWidget != null) roomsWidget.AddEntity();
            else if (reservesWidget != null) reservesWidget.AddEntity();
            else if (visitorsWidget != null) visitorsWidget.AddEntity();
        }
    }
}