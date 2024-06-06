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

namespace WpfApp5
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

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "" || ((TextBox)sender).Text == " ")
            {
                MessageBox.Show("Ошибка! Вы оставили поле пустым. Все поля должны быть заполнены");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(var el in TBGrid.Children)
            {
                if ((el as StackPanel) != null)
                {
                    foreach(var el2 in (el as StackPanel).Children)
                    {
                        if ((el as TextBox) != null)
                        {
                            MessageBox.Show("TB");
                        }
                    }
                }
            }
        }
    }
}