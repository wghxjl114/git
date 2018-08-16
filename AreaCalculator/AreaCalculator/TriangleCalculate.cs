using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    class TriangleCalculate : Calculate
    {
        public double Calculator(double data1, double data2, double data3)
        {
            double p = (data1 + data2 + data3) / 2;
            double area1 = Math.Sqrt(p * (p - data1) * (p - data2) * (p - data3));
            return area1;
        }
        public string CalculateArea(string unit, double data1, double data2, double data3)
        {
            if (unit == "cm")
            {
                
                double area1 = this.Calculator(data1, data2, data3);
                string ReturnString = area1.ToString("0.000") + "cm^2";
                return ReturnString;
            }
            else
            {
                
                double area1 = this.Calculator(2.54*data1, 2.54*data2, 2.54*data3);
                string ReturnString = area1.ToString("0.000") + "cm^2";
                return ReturnString;
            }
        }
            public string CalculateArea2(string unit, string Point1x, string Point1y,string Point2x, string Point2y, string Point3x,string Point3y )
        {
            if (unit== "cm")
            {
                double x1 = Convert.ToDouble(Point1x);
                double y1 = Convert.ToDouble(Point1y);
                double x2 = Convert.ToDouble(Point2x);
                double y2 = Convert.ToDouble(Point2y);
                double x3 = Convert.ToDouble(Point3x);
                double y3 = Convert.ToDouble(Point3y);
                double a = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                double b = Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));
                double c = Math.Sqrt((x2 - x3) * (x2 - x3) + (y2 - y3) * (y2 - y3));
                double p = (a + b + c) / 2;
                double area1 = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                string ReturnString1 = area1.ToString("0.000") + "cm^2";
                return ReturnString1;
            }
            else
            {
                double x1 = Convert.ToDouble(Point1x);
                double y1= Convert.ToDouble(Point1y);
                double x2 = Convert.ToDouble(Point2x);
                double y2 = Convert.ToDouble(Point2y);
                double x3 = Convert.ToDouble(Point3x);
                double y3 = Convert.ToDouble(Point3y);
                double a = 2.54*Math.Sqrt((x1- x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                double b = 2.54*Math.Sqrt((x1 - x3) * (x1- x3) + (y1 - y3) * (y1 - y3));
                double c = 2.54*Math.Sqrt((x2 - x3) * (x2 - x3) + (y2 - y3) * (y2 - y3));
                double p = (a + b + c) / 2;
                double area2 = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                string ReturnString2 = area2.ToString("0.000") + "cm^2";
                return ReturnString2;
            }
        }
    }
}
