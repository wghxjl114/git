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

namespace AreaCalculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RetangleButton_Click(object sender, RoutedEventArgs e)
        {
            Rectangle re = new Rectangle();
            re.Show();
            this.Close();
            
        }

        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            Square sq = new Square();
            sq.Show();
            this.Close();
           
        }

        private void TriangleButton_Click(object sender, RoutedEventArgs e)
        {
            Triangle tr = new Triangle();
            tr.Show();
            this.Close();
           
        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            Circle ci = new Circle();
            ci.Show();
            this.Close();
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
