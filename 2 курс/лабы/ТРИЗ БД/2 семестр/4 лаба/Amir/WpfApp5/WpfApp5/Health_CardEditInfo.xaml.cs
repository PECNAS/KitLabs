using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для Health_CardEditInfo.xaml
    /// </summary>
    public partial class Health_CardEditInfo : Window
    {
        private Health_Card _currentStand = new Health_Card();
        Health_Card bd = new Health_Card();
        public Health_CardEditInfo(Health_Card selectHealth)
        {
            InitializeComponent();
            if (selectHealth == null) return;
            _currentStand = selectHealth;
            DataContext = _currentStand;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var flag = true;
            foreach (Control c in GridEdit.Children)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (((TextBox)c).Text == String.Empty)
                    {
                        flag = false;
                    }
                }
                if (c.GetType() == typeof(ComboBox))
                {
                    if (((ComboBox)c).Text == String.Empty)
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                Statement_curatorEntities.GetContext().SaveChanges();
                MessageBox.Show("Ура! Изменилось!");
                new Health_Card().Show();
                Close();
            }
            else MessageBox.Show("Пусто и грустно :( ");
        }
        private void ButtonEditBack_Click(object sender, RoutedEventArgs e)
        {
            new Health_Card().Show();
            Close();
        }
    }
}
