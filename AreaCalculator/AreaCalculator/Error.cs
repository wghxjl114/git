using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace AreaCalculator
{
   public static class Warning
    {
        [DllImport("user32.dll")]
        public static extern int MessageBeep(uint uType);
        public static void Sound()
        {
            uint Beep = 0x00000000;
            MessageBeep(Beep);
        }
    }
}
