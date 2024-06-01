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
    /// Логика взаимодействия для CuratorsEditInfo.xaml
    /// </summary>
    public partial class CuratorsEditInfo : Window
    {
        private Curator _currentCurator = new Curator();
        Statement_curatorEntities bd = new Statement_curatorEntities();
        public CuratorsEditInfo(Curator selectCurator)
        {
            InitializeComponent();
            if (selectCurator == null) return;
            _currentCurator = selectCurator;
            DataContext = _currentCurator;
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
                new Curators().Show();
                Close();
            }
            else MessageBox.Show("Пусто и грустно :( ");
        }

        private void ButtonEditBack_Click(object sender, RoutedEventArgs e)
        {
            Curators curator = new Curators();
            curator.Show();
            this.Hide();
        }
    }
}
