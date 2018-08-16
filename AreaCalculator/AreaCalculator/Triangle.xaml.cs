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
            if (unit == "cm")
            {
                double data1 = Convert.ToDouble(Side1Textbox.Text);
                double data2 = Convert.ToDouble(Side2Textbox.Text);
                double data3 = Convert.ToDouble(Side3Textbox.Text);
                double p = (data1 + data2 + data3) / 2;
                double area1 = Math.Sqrt(p*(p-data1)*(p-data2)*(p-data3));
                string a = area1.ToString("0.000");
                TriangleAreaTextbox.Text = a + "cm^2";
            }
            else if (unit == "in")
            {
                double data1 =2.54* (Convert.ToDouble(Side1Textbox.Text));
                double data2 = 2.54*(Convert.ToDouble(Side2Textbox.Text));
                double data3 =2.54*( Convert.ToDouble(Side3Textbox.Text));
                double p = (data1 + data2 + data3) / 2;
                double area1 = Math.Sqrt(p * (p - data1) * (p - data2) * (p - data3));
                string a = area1.ToString("0.000");
               TriangleAreaTextbox.Text = a + "cm^2";
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
           
        }

        private void RectangleCalculateButton2_Click(object sender, RoutedEventArgs e)
        {
            if (unit2 == "cm")
            {
                double x1 = Convert.ToDouble(Point1XTextbox.Text);
                double y1 = Convert.ToDouble(Point1YTextbox.Text);
                double x2 = Convert.ToDouble(Point2XTextbox.Text);
                double y2 = Convert.ToDouble(Point2YTextbox.Text);
                double x3 = Convert.ToDouble(Point3XTextbox.Text);
                double y3 = Convert.ToDouble(Point3YTextbox.Text);
                double a = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                double b = Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));
                double c = Math.Sqrt((x2 - x3) * (x2 - x3) + (y2 - y3) * (y2 - y3));
                double p = (a + b + c) / 2;
                double area1 = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                string m= area1.ToString("0.000");
                TriangleAreaTextbox2.Text = m + "cm^2";
            }
            else if (unit2 == "in")
            {
                double x1 = Convert.ToDouble(Point1XTextbox.Text);
                double y1 = Convert.ToDouble(Point1YTextbox.Text);
                double x2 = Convert.ToDouble(Point2XTextbox.Text);
                double y2 = Convert.ToDouble(Point2YTextbox.Text);
                double x3 = Convert.ToDouble(Point3XTextbox.Text);
                double y3 = Convert.ToDouble(Point3YTextbox.Text);
                double a = 2.54*Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                double b = 2.54*Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));
                double c = 2.54*Math.Sqrt((x2 - x3) * (x2 - x3) + (y2 - y3) * (y2 - y3));
                double p = (a + b + c) / 2;
                double area1 = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                string m= area1.ToString("0.000");
                TriangleAreaTextbox2.Text = m + "cm^2";
            }
            else
            {
                MessageBox.Show("You must choose a unit!");
            }
        }
    }
}
