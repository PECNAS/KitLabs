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

namespace WpfApp1.Templates
{
    /// <summary>
    /// Логика взаимодействия для MainWidget.xaml
    /// </summary>
    public partial class MainWidget : UserControl
    {
        MainWindow root;
        public MainWidget(MainWindow root)
        {
            InitializeComponent();
            this.root = root;
        }
    }
}
