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
    /// Логика взаимодействия для ParentsEditInfo.xaml
    /// </summary>
    public partial class ParentsEditInfo : Window
    {
        private Parents _currentParent = new Parents();
        Statement_curatorEntities bd = new Statement_curatorEntities();
        public ParentsEditInfo(Parents selectParent)
        {
            InitializeComponent();
            if (selectParent == null) return;
            _currentParent = selectParent;
            DataContext = _currentParent;
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
                new Parent().Show();
                Close();
            }
            else MessageBox.Show("Пусто и грустно :( ");
        }
    }
}
