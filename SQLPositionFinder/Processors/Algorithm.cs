using SQLPositionFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLPositionFinder.Processors
{
    public class Algorithm
    {
        List<IBssidData> DataPoints;
        SQLRunner sqlRunner;
        public Algorithm( List<IBssidData> lst)
        {
            DataPoints = lst;
            sqlRunner = new SQLRunner();
        }

        Dictionary<string, int> FloorDict = new Dictionary<string, int>();
        public int Process()
        {
            int dummy, MaxDistance = 0;
            bool DoContinue = true;
            string RetValue = null;
            while (DoContinue && MaxDistance < 30)
            {
                // 1.) Dla wszystkich bssid policz ilosc punktow z roznica sygnalu max 0
                // 2.) Jezeli wyniki nie sa puste, to sprawdz jakie pietro sie najszesciej powtarza i je zwroc
                // 3.) Jezeli wyniki sa puste, to idz do punktu 1.)
                foreach (var item in DataPoints)
                {
                    var lst = sqlRunner.GetFloorCountForPairData(item, MaxDistance);
                    // Dodaj dane do wiekszej tabeli
                    foreach (var item2 in lst)
                    {
                        if (!FloorDict.TryGetValue(item2.FloorNumber, out dummy))
                            FloorDict.Add(item2.FloorNumber, 0);
                        FloorDict[item2.FloorNumber] += item2.CountNumber;

                    }
                }


                var MostPropableFloor = FloorDict.OrderByDescending(x => x.Value).FirstOrDefault();
                if (MostPropableFloor.Key != null)
                {
                    RetValue = MostPropableFloor.Key;
                    DoContinue = false;
                }
                else
                {
                    MaxDistance += 5;
                }
            }
            if (RetValue == null)
                return -1;
            int output;
            if(int.TryParse(RetValue,out output))
            {
                return output;
            }

            return -1;
        }



    }
}
