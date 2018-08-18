using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    class TriangleCalculate : Calculate
    {
        public override double Calculator(double data1, double data2, double data3)
        {
            double p = (data1 + data2 + data3) / 2;
            double area1 = Math.Sqrt(p * (p - data1) * (p - data2) * (p - data3));
            return area1;
        }
        public string CalculateArea(string unit, params double[] data)
        {
                double area1 = Calculator(data[0], data[1], data[2]);
                string ReturnString = area1.ToString("0.000") + "cm^2";
                return ReturnString;
        }
        public override string CalculateArea(string unit,params  string[] Point)
        {
            double[] data = new double[Point.GetLength(0)];
            if (unit == "cm")
            {
                for (int i = 0; i < Point.GetLength(0); i++)
                    data[i] = Convert.ToDouble(Point[i]);
            }
            else
            {
                for (int i = 0; i < Point.GetLength(0); i++)
                    data[i] = 2.54 * Convert.ToDouble(Point[i]);
            }
                double a = Math.Sqrt((data[0]-data[2]) * (data[0] - data[2]) + (data[1] - data[3]) * (data[1] - data[3]));
                double b = Math.Sqrt((data[0] - data[4]) * (data[0] - data[4]) + (data[1]-data[5]) * (data[1] - data[5]));
                double c = Math.Sqrt((data[2]-data[4]) * (data[2] - data[4]) + (data[3]-data[5]) * (data[3] - data[5]));
                double p = (a + b + c) / 2;
                double area1 = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                string ReturnString1 = area1.ToString("0.000") + "cm^2";
                return ReturnString1;
        }
    }
}
