using SQLPositionFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLPositionFinder.Processors
{
    public class DataPoint : IBssidData
    {
        public string Bssid { get; set; }

        public int SignalStrength { get; set; }
    }
}
