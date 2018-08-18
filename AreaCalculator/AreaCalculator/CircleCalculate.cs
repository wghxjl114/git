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
        public override double Calculator(double data1)
        {
            return data1 * data1*PI;
        }
    }
}
