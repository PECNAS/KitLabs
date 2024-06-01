using System.Configuration;
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

namespace CanvasApp
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
        
        public void ColorHandler(object sender, RoutedEventArgs e)
        {
            if (combo_box.SelectedIndex == 0) canv.DefaultDrawingAttributes.Color = Colors.Red;
            else if (combo_box.SelectedIndex == 1) canv.DefaultDrawingAttributes.Color = Colors.Green;
            else if (combo_box.SelectedIndex == 2) canv.DefaultDrawingAttributes.Color = Colors.Blue;
        }

        public void RadioHandler(object sender, RoutedEventArgs e)
        {
            if (RB_1.IsChecked == true) canv.EditingMode = InkCanvasEditingMode.Ink;
            if (RB_2.IsChecked == true) canv.EditingMode = InkCanvasEditingMode.Select;
            if (RB_3.IsChecked == true) canv.EditingMode = InkCanvasEditingMode.EraseByPoint;
            if (RB_4.IsChecked == true) canv.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider s = (Slider)sender;
            if (s.Value > 1)
            {
                int value = (int)s.Value;
                this.canv.DefaultDrawingAttributes.Height = value;
                this.canv.DefaultDrawingAttributes.Width = value;
                draw_size.Content = value;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}