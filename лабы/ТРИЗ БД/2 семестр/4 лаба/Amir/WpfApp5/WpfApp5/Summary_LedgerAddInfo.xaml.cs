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
    /// Логика взаимодействия для Summary_LedgerAddInfo.xaml
    /// </summary>
    public partial class Summary_LedgerAddInfo : Window
    {
        private readonly Summary_Ledger _currentSum = new Summary_Ledger();
        private readonly Statement_curatorEntities _bd = new Statement_curatorEntities();
        public Summary_LedgerAddInfo()
        {
            InitializeComponent();
            DataContext = _currentSum;

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

                Statement_curatorEntities.GetContext().Summary_Ledger.Add(_currentSum);
                Statement_curatorEntities.GetContext().SaveChanges();
                MessageBox.Show("Ура! Добавилось!");
                new Summary_Ledger().Show();
                this.Close();



            }
            else
            {
                MessageBox.Show("Пусто и грустно :(");
            }
        }

        private void ButtonAddBack_Click(object sender, RoutedEventArgs e)
        {
            Summary_Ledger summary_ledger = new Summary_Ledger();
            summary_ledger.Show();
            this.Hide();
        }
    }
}
