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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.InsertWindows;
using WpfApp1.Models;

namespace WpfApp1.DataWindows
{
    /// <summary>
    /// Логика взаимодействия для AppDataWindow.xaml
    /// </summary>
    public partial class AppDataWindow : Window
    {
        Executor exec;
        string CurrentTable;

        public AppDataWindow(Executor exec)
        {
            InitializeComponent();
            this.exec = exec;
        }

        private void UpdateData()
        {
            List<object> items = new List<object>();
            using (var db = new MobileContext())
            {
                if (CurrentTable == "Заявки") { foreach (var el in db.Apps) { items.Add(el); } }
                else if (CurrentTable == "Клиенты") { foreach (var el in db.Clients) { items.Add(el); } }
                else if (CurrentTable == "Категории") { foreach (var el in db.Categories) { items.Add(el); } }
                else if (CurrentTable == "Исполнители") { foreach (var el in db.Executors) { items.Add(el); } }
                else if (CurrentTable == "История") { foreach (var el in db.Histories) { items.Add(el); } }
            }

            DataTable.ItemsSource = items;

        }

        public void LoadData(object sender, RoutedEventArgs e)
        {
            List<object> items = new List<object>();

            using (var db = new MobileContext()) {
                if ((sender as MenuItem).Header.ToString() == "Заявки") { foreach (var el in db.Apps) { items.Add(el); } }
                else if ((sender as MenuItem).Header.ToString() == "Клиенты") { foreach (var el in db.Clients) { items.Add(el); } }
                else if ((sender as MenuItem).Header.ToString() == "Категории") { foreach (var el in db.Categories) { items.Add(el); } }
                else if ((sender as MenuItem).Header.ToString() == "Исполнители") { foreach (var el in db.Executors) { items.Add(el); } }
                else if ((sender as MenuItem).Header.ToString() == "История") { foreach (var el in db.Histories) { items.Add(el); } }

                CurrentTable = (sender as MenuItem).Header.ToString();
            }

            DataTable.ItemsSource = items;
            
        }

        public void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window2(this.exec);
            win.Show();
            this.Close();
        }

        public void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = DataTable.SelectedItem;
            if (selected != null)
            {
                if (CurrentTable == "Заявки")
                {
                    var win = new AppInsertWindow(this.exec, (Models.App)selected);
                    win.ShowDialog();
                }
                else if (CurrentTable == "Клиенты")
                {
                    var win = new ClientInsertWindow(this.exec, (Client)selected);
                    win.ShowDialog();
                }
                else if (CurrentTable == "Категории")
                {
                    var win = new CategoryInsertWindow(this.exec, (Category)selected);
                    win.ShowDialog();
                }
                else if (CurrentTable == "Исполнители")
                {
                    var win = new ExecutorInsertWindow(this.exec, (Executor)selected);
                    win.ShowDialog();
                }
                else if (CurrentTable == "История")
                {
                    var win = new HistoryInsertWindow(this.exec, (History)selected);
                    win.ShowDialog();
                }
            } else MessageBox.Show("Не выбрана ни одна строка!");

            UpdateData();
        }

        public void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTable == "Заявки")
            {
                var win = new AppInsertWindow(this.exec);
                win.ShowDialog();
            }
            else if (CurrentTable == "Клиенты")
            {
                var win = new ClientInsertWindow(this.exec);
                win.ShowDialog();
            }
            else if (CurrentTable == "Категории")
            {
                var win = new CategoryInsertWindow(this.exec);
                win.ShowDialog();
            }
            else if (CurrentTable == "Исполнители")
            {
                var win = new ExecutorInsertWindow(this.exec);
                win.ShowDialog();
            }
            else if (CurrentTable == "История")
            {
                var win = new HistoryInsertWindow(this.exec);
                win.ShowDialog();
            }
            UpdateData();

        }

        public void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = DataTable.SelectedItem;
            if (selected == null) return;

            var result = MessageBox.Show(
                    "Вы уверены, что хотите выполнить удаление выбранного объекта?",
                    "Удаление",
                    MessageBoxButton.YesNo
                );
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new MobileContext())
                {
                    if (CurrentTable == "Заявки") { db.Apps.Remove(db.Apps.First( x => x.Id == ((Models.App)selected).Id)); }
                    else if (CurrentTable == "Клиенты") { db.Clients.Remove(db.Clients.First(x => x.Id == ((Client)selected).Id)); }
                    else if (CurrentTable == "Категории") { db.Categories.Remove(db.Categories.First(x => x.Id == ((Category)selected).Id)); }
                    else if (CurrentTable == "Исполнители") { db.Executors.Remove(db.Executors.First(x => x.Id == ((Executor)selected).Id)); }
                    else if (CurrentTable == "История") { db.Histories.Remove(db.Histories.First(x => x.Id == ((History)selected).Id)); }

                    db.SaveChanges();
                    UpdateData();
                }
                MessageBox.Show("Удаление завершено");
            }
        }
    }
}
