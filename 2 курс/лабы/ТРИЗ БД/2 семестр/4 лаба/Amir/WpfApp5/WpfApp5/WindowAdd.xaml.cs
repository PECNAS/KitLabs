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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        private readonly Student _currentStand = new Student();
        private readonly Statement_curatorEntities _bd = new Statement_curatorEntities();
        public WindowAdd()
        {
            InitializeComponent();
        }
        private void ButtonAddBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
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

                Statement_curatorEntities.GetContext().Student.Add(_currentStand);
                Statement_curatorEntities.GetContext().SaveChanges();
                MessageBox.Show("Ура! Добавилось!");
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пусто и грустно :(");
            }
        }
    }
}
