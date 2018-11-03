using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11
{
   public class CardEventArgs:EventArgs
    {
        public Card Card { get; set; }
    }
}
