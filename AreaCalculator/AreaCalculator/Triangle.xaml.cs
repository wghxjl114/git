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
using System.Runtime.InteropServices;

namespace AreaCalculator
{
    /// <summary>
    /// Triangle.xaml 的交互逻辑
    /// </summary>
    public partial class Triangle : Window
    {
        [DllImport("user32.dll")]
        public static extern int MessageBeep(uint uType);
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
            if (unit == "cm" || unit == "in")
            {
                double data1 = Convert.ToDouble(Side1Textbox.Text);
                double data2 = Convert.ToDouble(Side2Textbox.Text);
                double data3 = Convert.ToDouble(Side3Textbox.Text);
                if((data1+data2>data3)&&(data1+data3>data2)&&(data2+data3>data1))
               {
                    TriangleCalculate MyTriangleCalculate = new TriangleCalculate();
                    TriangleAreaTextbox.Text = MyTriangleCalculate.CalculateArea(unit, data1, data2, data3);
                }
                else
                {
                    uint Beep = 0x00000000;
                    MessageBeep(Beep);
                    MessageBox.Show("This is not a triangle!");
                }
            }
            else
            {
                uint Beep = 0x00000000;
                MessageBeep(Beep);
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
            if (unit2 == "cm"||unit2=="in")
            {
                TriangleCalculate MyTriangleCalculate = new TriangleCalculate();
                TriangleAreaTextbox2.Text = MyTriangleCalculate.CalculateArea2(unit2, Point1XTextbox.Text, Point1YTextbox.Text,Point2XTextbox.Text, Point2YTextbox.Text, Point3XTextbox.Text, Point3YTextbox.Text);
            }
            else
            {
                uint Beep = 0x00000000;
                MessageBeep(Beep);
                MessageBox.Show("You must choose a unit!");
            }
        }
    }
}
