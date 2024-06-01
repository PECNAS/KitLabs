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
    /// Логика взаимодействия для Summary_Ledger.xaml
    /// </summary>
    public partial class Summary_Ledger : Window
    {
        public Summary_Ledger()
        {
            InitializeComponent();
        }
        private void ButtonList_Click_1(object sender, RoutedEventArgs e)
        {
            DataGridStudent.ItemsSource = Statement_curatorEntities.GetContext().Summary_Ledger.ToList();

        }

        private void ButtonAdd_Click_1(object sender, RoutedEventArgs e)
        {
            Summary_LedgerAddInfo summary_ledgerAddInfo = new Summary_LedgerAddInfo();
            summary_ledgerAddInfo.Show();
            this.Hide();
        }
    }
}
