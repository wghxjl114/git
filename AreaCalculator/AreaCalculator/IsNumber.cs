using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    public static class Judge
    {
        public static bool IsNumber(string content)
        {
            try
            {
                Convert.ToDouble(content);
                return true;
            }
            catch(System.FormatException)
            {
                return false;
            }
        }
    }
}
