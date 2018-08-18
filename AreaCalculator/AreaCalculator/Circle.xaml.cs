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
    /// Circle.xaml 的交互逻辑
    /// </summary>
    public partial class Circle : Window
    {
        public Circle()
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
            if (Judge.IsNumber(RadiusTextbox.Text))
            {
                CircleCalculate MyCircleCalculate = new CircleCalculate();
                AreaTextbox.Text = MyCircleCalculate.CalculateArea(unit, RadiusTextbox.Text);
            }
            else
            {
                Warning.Sound();
                MessageBox.Show("The things you input must be numbers!");
            }
            
        }

        private void RectangleOKButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
           
        }
    }
}
