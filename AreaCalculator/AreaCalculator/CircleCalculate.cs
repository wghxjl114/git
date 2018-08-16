using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    public class CircleCalculate:Calculate
    {
        static double PI = 3.1415926;
        public string CalculateArea(string unit, string Text1)
        {
            if (unit == "cm")
            {
                double data1 = Convert.ToDouble(Text1);
                double area1 = Calculator(data1);
                string ReturnString = area1.ToString("0.000") + "cm^2";
                return ReturnString;
            }
            else
            {
                double data1 = 2.54 * Convert.ToDouble(Text1);
                double area1 = Calculator(data1);
                string a = area1.ToString("0.000") + "cm^2";
                return a;
            }
        }
        public double Calculator(double data1)
        {
            return data1 * data1*PI;
        }
    }
}
