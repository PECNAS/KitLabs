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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Бусов Владислав Романович 4238");
        }

        private void ButtonInfo_MouseEnter(object sender, MouseEventArgs e)
        {
            Stat.Text = "Выводит информацию о разработчике";
        }

        private void ButtonClose_MouseEnter(object sender, MouseEventArgs e)
        {
            Stat.Text = "Закрывает программу";
        }

        private void ButtonColor_MouseEnter(object sender, MouseEventArgs e)
        {
            Stat.Text = "Изменяет цвет фона";
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Stat.Text = "Ожидание...";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}