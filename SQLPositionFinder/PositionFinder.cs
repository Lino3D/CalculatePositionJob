using SQLPositionFinder.Interfaces;
using SQLPositionFinder.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLPositionFinder
{
    public class PositionFinder
    {
        public int FindFLoor(IEnumerable<IBssidData> lst)
        {


            return -1;
        }
        public int FindFloor(string BssidDataString)
        {
            Algorithm algorithm;
            try
            {
                 algorithm = new Algorithm(MessageToList(BssidDataString).ToList());
            }
            catch(Exception e)
            {
                return -1;
            }
            return algorithm.Process();            
        }


        // Przykladowy format danych: "64ae0c861fb0,-87;"
        private IEnumerable<IBssidData> MessageToList(string message)
        {
            List<DataPoint> lst = new List<DataPoint>();
            var DataPairs = message.Split(';');
            foreach (var item in DataPairs)
            {
                if (item == "")
                    break;
                var SinglePoint = item.Split(',');
                if (SinglePoint.Count() != 2)
                    throw new Exception("Data point się nie zgadza, sprawdź poprawność przesłanych danych!");
                int ConvertedInt;
                if (!int.TryParse(SinglePoint.ElementAt(1), out ConvertedInt))
                    throw new Exception("Exception przy konwertowaniu sily sygnalu!");
                DataPoint p = new DataPoint() { Bssid = SinglePoint.ElementAt(0), SignalStrength = ConvertedInt };
                lst.Add(p);
            }
            return lst;
        }        
    }
}
