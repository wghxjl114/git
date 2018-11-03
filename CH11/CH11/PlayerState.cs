using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH11
{
    [Serializable]
    public enum PlayerState
    {
        Inactive,
        Active,
        MustDiscard,
        Winner,
        Loser
    }
}
