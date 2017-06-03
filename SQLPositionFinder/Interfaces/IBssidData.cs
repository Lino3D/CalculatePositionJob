using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLPositionFinder.Interfaces
{
    public interface IBssidData
    {
        int SignalStrength { get; set; }
        string Bssid { get; set; }
    }
}
