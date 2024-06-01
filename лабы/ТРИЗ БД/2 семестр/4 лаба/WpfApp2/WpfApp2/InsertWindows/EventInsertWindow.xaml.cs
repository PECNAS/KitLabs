using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp2.InsertWindows
{
    /// <summary>
    /// Логика взаимодействия для EventInsertWindow.xaml
    /// </summary>
    public partial class EventInsertWindow : Window
    {
        private readonly Event _currentEvent = new Event();
        private readonly trizbd_bdEntities1 _bd = new trizbd_bdEntities1();
        public EventInsertWindow(Event ev = null)
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Добавление записи";
            if (ev != null)
            {
                this._currentEvent = ev;
                this.TitleTextBlock.Text = "Редактирование записи";
                EventTitleTB.Text = ev.event_title;
                EventKindTB.Text = ev.kind_of_event;
                EventDateTB.Text = ev.event_date;
                EventTimeTB.Text = ev.event_time;

            }
            DataContext = _currentEvent;

        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            bool flag = (
                MainWindow.DateCheck(EventDateTB.Text) &&
                MainWindow.TimeCheck(EventTimeTB.Text)
            );
                
            if (flag)
            {
                _currentEvent.event_title = EventTitleTB.Text;
                _currentEvent.kind_of_event = EventKindTB.Text;
                _currentEvent.event_date = EventDateTB.Text;
                _currentEvent.event_time = EventTimeTB.Text;

                trizbd_bdEntities1.GetContext().Events.AddOrUpdate(_currentEvent);
                trizbd_bdEntities1.GetContext().SaveChanges();
                MessageBox.Show("Ура, добавилось!");
                this.Close();
            }
            else { MessageBox.Show("Ошибка! Проверьте данные!"); }
        }
    }
}
