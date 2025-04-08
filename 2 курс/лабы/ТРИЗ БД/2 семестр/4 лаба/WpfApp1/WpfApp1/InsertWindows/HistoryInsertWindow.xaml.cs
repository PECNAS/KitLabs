using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using WpfApp1.Models;

namespace WpfApp1.InsertWindows
{
    /// <summary>
    /// Логика взаимодействия для HistoryInsertWindow.xaml
    /// </summary>
    public partial class HistoryInsertWindow : Window
    {
        History current;
        public HistoryInsertWindow(Executor exec, History current = null)
        {
            this.current = current;
            InitializeComponent();

            if (current != null)
            {
                HistoryExecId.Text = current.ExecId.ToString();
                HistoryAppId.Text = current.AppId.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(HistoryExecId.Text, out int exec_id)) MessageBox.Show("Id должно быть числом");
            else if (!int.TryParse(HistoryAppId.Text, out int app_id)) MessageBox.Show("Id должно быть числом");
            else
            {
                var hist = new History
                {
                    AppId = app_id,
                    ExecId = exec_id
                };

                if (current != null) hist.Id = current.Id;

                using (var db = new MobileContext())
                {
                    db.Histories.AddOrUpdate(hist);
                    db.SaveChanges();
                }

                MessageBox.Show("Запись успешно добавлена!");
                this.Close();
            }
        }
    }
}
