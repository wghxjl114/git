using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    public class Calculate
    {
        public virtual string CalculateArea(string unit, params string[] Text)
        {
            double[] data = new double[Text.GetLength(0)];
            if (unit == "cm")
            {
                for (int i = 0; i < Text.GetLength(0); i++)
                    data[i] = Convert.ToDouble(Text[i]);
            }
            else
            {
                for (int i = 0; i < Text.GetLength(0); i++)
                    data[i] = 2.54 * Convert.ToDouble(Text[i]);
            }
            if(Text.GetLength(0)==1)
            {
                double area1 = Calculator(data[0]);
                string ReturnString = area1.ToString("0.000") + "cm^2";
                return ReturnString;
            }
            else if (Text.GetLength(0) == 2)
            {
                double area1 = Calculator(data[0], data[1]);
                string ReturnString = area1.ToString("0.000") + "cm^2";
                return ReturnString;
            }
            else
            {

                double area1 = Calculator(data[0], data[1], data[2]);
                string ReturnString = area1.ToString("0.000") + "cm^2";
                return ReturnString;
            }
        }
        public virtual double Calculator(double data)
        {
            return 0;
        }
        public virtual double Calculator(double data1,double data2)
        {
            return data1 * data2;
        }
        public virtual double Calculator(double data1, double data2,double data3)
        {
            return 0;
        }
    }
}
