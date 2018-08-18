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
    /// Triangle.xaml 的交互逻辑
    /// </summary>
    public partial class Triangle : Window
    {
        public Triangle()
        {
            InitializeComponent();
        }
        static string unit;
        static string unit2;
        private void Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = Unit.SelectedItem as ComboBoxItem;
            string content = item.Content.ToString();
            unit = content;

        }
        private void Unit2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item2 = Unit2.SelectedItem as ComboBoxItem;
            string content2 = item2.Content.ToString();
            unit2 = content2;

        }
        private void RectangleCalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Judge.IsNumber(Side1Textbox.Text) && Judge.IsNumber(Side2Textbox.Text) && Judge.IsNumber(Side3Textbox.Text))
            {
                double data1 = Convert.ToDouble(Side1Textbox.Text);
                double data2 = Convert.ToDouble(Side2Textbox.Text);
                double data3 = Convert.ToDouble(Side3Textbox.Text);
                if ((data1 + data2 > data3) && (data1 + data3 > data2) && (data2 + data3 > data1))
                {
                    TriangleCalculate MyTriangleCalculate = new TriangleCalculate();
                    TriangleAreaTextbox.Text = MyTriangleCalculate.CalculateArea(unit, data1, data2, data3);
                }
                else
                {
                    Warning.Sound();
                    MessageBox.Show("This is not a triangle!");
                }
            }
            else
            {
                Warning.Sound();
                MessageBox.Show("The things you input must be numbers!");
            }
        }

        private void RectangleOKButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow n = new MainWindow();
            n.Show();
            this.Close();

        }

        private void RectangleCalculateButton2_Click(object sender, RoutedEventArgs e)
        {

            if (Judge.IsNumber(Point1XTextbox.Text) && Judge.IsNumber(Point1YTextbox.Text) && Judge.IsNumber(Point2XTextbox.Text) && Judge.IsNumber(Point2YTextbox.Text) && Judge.IsNumber(Point3XTextbox.Text) && Judge.IsNumber(Point3YTextbox.Text))
            {
                TriangleCalculate MyTriangleCalculate = new TriangleCalculate();
                TriangleAreaTextbox2.Text = MyTriangleCalculate.CalculateArea(unit2, Point1XTextbox.Text, Point1YTextbox.Text, Point2XTextbox.Text, Point2YTextbox.Text, Point3XTextbox.Text, Point3YTextbox.Text);
            }
            else
            {
                Warning.Sound();
                MessageBox.Show("The things you input must be numbers!");
            }
        }
    }
}
