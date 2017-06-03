using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLPositionFinder.DataObjects
{
    public class DataFloorPoint
    {
        public string FloorNumber { get; set; }
        public int CountNumber { get; set; }
        public DataFloorPoint(string floor, int count)
        {
            FloorNumber = floor;
            CountNumber = count;
        }
    }
}
