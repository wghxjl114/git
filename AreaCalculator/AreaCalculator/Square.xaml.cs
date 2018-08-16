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

namespace AreaCalculator
{
    /// <summary>
    /// Square.xaml 的交互逻辑
    /// </summary>
    public partial class Square : Window
    {
        public Square()
        {
            InitializeComponent();
        }
         static string unit;
        private void Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = Unit.SelectedItem as ComboBoxItem;
            string content = item.Content.ToString();
            unit = content;
           
        }

        private void RectangleCalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (unit == "cm")
            {
                double data1 = Convert.ToDouble(SideLengthTextbox.Text);
                double area1 = data1 * data1;
                string a=area1.ToString("0.000");
                SquareAreaTextbox.Text = a+"cm^2";
            }
            else if (unit == "in")
            {
                double data1 = Convert.ToDouble(SideLengthTextbox.Text);
                double area1 =2.54*data1 *2.54* data1;
                string a = area1.ToString("0.000");
                SquareAreaTextbox.Text = a+"cm^2";
            }
            else
            {
                MessageBox.Show("You must choose a unit!");
            }
        }

        private void RectangleOKButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow n = new MainWindow();
            n.Show();
            this.Close();
           ;
        }
    }
}
