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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void escapeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Random random = new Random();

            // Получаем размеры окна
            double windowWidth = this.ActualWidth;
            double windowHeight = this.ActualHeight;

            // Генерируем случайные координаты для кнопки
            double randomX = random.NextDouble() * (windowWidth - escapeButton.ActualWidth);
            double randomY = random.NextDouble() * (windowHeight - escapeButton.ActualHeight);

            // Устанавливаем новые случайные координаты для кнопки
            escapeButton.Margin = new Thickness(randomX, randomY, 0, 0);
        }
    }
}