using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MenuApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Red;
        }

        private void MenuItem_MouseEnter(object sender, RoutedEventArgs e)
        {
            StatusBar_TextBlock.Text = "Красный";
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Green;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Blue;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.White;
        }

        private void MenuItem_MouseEnter_1(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "Зелёный";
        }

        private void MenuItem_MouseEnter_2(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "Синий";
        }

        private void MenuItem_MouseEnter_3(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "Белый";
        }

        private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "";
        }

        private void MenuItem_MouseLeave_1(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "";
        }

        private void MenuItem_MouseLeave_2(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "";
        }

        private void MenuItem_MouseLeave_3(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "";
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная программа содержит в себе меню, панель управления и строку состояния. " +
                "Через меню и панель управления вы можете сменить цвет заднего фона, прочитать это " +
                "сообщение и закрыть программу. В строке состояния отмечается выбранный вами вариант!");
        }

        private void MenuItem_MouseEnter_4(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "О программе";
        }

        private void MenuItem_MouseLeave_4(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "";
        }

        private void MenuItem_MouseEnter_5(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "Закрыть программу";
        }

        private void MenuItem_MouseLeave_5(object sender, MouseEventArgs e)
        {
            StatusBar_TextBlock.Text = "";
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}