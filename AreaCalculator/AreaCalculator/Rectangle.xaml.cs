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
    /// Rectangle.xaml 的交互逻辑
    /// </summary>
    public partial class Rectangle : Window
    {
        [DllImport("user32.dll")]
        public static extern int MessageBeep(uint uType);
        public Rectangle()
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
            if (unit == "cm"||unit=="in")
            {
                Calculate MyCalculate = new Calculate();
                RectangleAreaTextbox.Text= MyCalculate.CalculateArea(unit, LengthTextbox.Text, WidthTextbox.Text);
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
    }
}
