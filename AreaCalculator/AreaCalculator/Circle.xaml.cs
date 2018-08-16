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
    /// Circle.xaml 的交互逻辑
    /// </summary>
    public partial class Circle : Window
    {
        [DllImport("user32.dll")]
        public static extern int MessageBeep(uint uType);
        public Circle()
        {
            InitializeComponent();
           
        }
        static string unit;
        static double PI = 3.1415926;
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
                double data1 = Convert.ToDouble(RadiusTextbox.Text);
                double area1 = PI * data1 * data1;
                string a=area1.ToString("0.000");
                AreaTextbox.Text = a+"cm^2";
            }
            else if (unit == "in")
            {
                double data1 = Convert.ToDouble(RadiusTextbox.Text);
                double area1 = PI * 2.54*data1 *2.54* data1;
                string a = area1.ToString("0.000");
                AreaTextbox.Text = a+"cm^2";
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
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
           
        }
    }
}
