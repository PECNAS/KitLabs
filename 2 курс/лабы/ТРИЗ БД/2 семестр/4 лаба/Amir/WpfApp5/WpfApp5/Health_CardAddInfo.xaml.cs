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
    /// Логика взаимодействия для Health_CardAddInfo.xaml
    /// </summary>
    public partial class Health_CardAddInfo : Window
    {
        private readonly Health_Card _currentStand = new Health_Card();
        private readonly Statement_curatorEntities _bd = new Statement_curatorEntities();
        public Health_CardAddInfo()
        {
            InitializeComponent();
            DataContext = _currentStand;
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var flag = true;
            foreach (Control c in GridAdd.Children)
            {
                if (c is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        flag = false;
                    }
                }
                if (c is ComboBox comboBox)
                {
                    if (comboBox.SelectedItem == null)
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
            {

                Statement_curatorEntities.GetContext().Health_Card.Add(_currentStand);
                Statement_curatorEntities.GetContext().SaveChanges();
                MessageBox.Show("Ура! Добавилось!");
                new Health_Card().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пусто и грустно :(");
            }
        }

        private void ButtonAddBack_Click(object sender, RoutedEventArgs e)
        {
            Health_Card store = new Health_Card();
            store.Show();
            this.Hide();
        }
    }
}
