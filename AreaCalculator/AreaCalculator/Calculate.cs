using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    public class Calculate
    {
        public string CalculateArea(string unit, string Text1, string Text2)
        {
            if (unit == "cm")
            {
                double data1 = Convert.ToDouble(Text1);
                double data2 = Convert.ToDouble(Text2);
                double area1 = Calculator(data1, data2);
                string ReturnString = area1.ToString("0.000") + "cm^2";
                return ReturnString;
            }
            else
            {
                double data1 = 2.54*Convert.ToDouble(Text1);
                double data2 = 2.54*Convert.ToDouble(Text1);
                double area1 = Calculator(data1, data2);
                string a = area1.ToString("0.000")+"cm^2";
                return a;
            }
        }
           public double Calculator(double data1,double data2)
        {
            return data1 * data2;
        }
    }
}
