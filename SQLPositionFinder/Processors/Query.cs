using SQLPositionFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLPositionFinder.Processors
{
    public class Query
    {
        public string GetQueryForWholeList() => $"select {ForDifference()} as diff, {ForParameters()}, {ForTableName()}  from {TableName} {ForWhereClause()}";

        public string GetQueryForFloorCountPair() => $"select count(*), floor {ForTableName()} from {TableName} {ForWhereClause()} group by floor";




        public Query(IBssidData data, int maxDistance)
        {
            BssidData = data;
            MaximumDifference = maxDistance;
        }

        public IBssidData BssidData { get; set; }
        public int MaximumDifference { get; set; }
        public string ColumnName = "wifigsm_rssi";
        public string TableName = "wifigsm";
        

        string ForSelect() => "select";
        string ForDifference() => $"ABS({ForTableName()} {GetSignalDifferenceString()})";
        string GetSignalDifferenceString()
        {
            if (BssidData.SignalStrength >= 0)
                return $"- {BssidData.SignalStrength}";
            else
                return $"+ {-BssidData.SignalStrength}";
        }
        string ForTableName() =>$"[{ColumnName}{BssidData.Bssid}]";
        
        string ForParameters() => "floor, id";

        string ForWhereClause() => $"where {ForTableName()} is not NULL and {ForTableName()} !='' and {ForDifference()} <= '{MaximumDifference}'";
        
        
    }
}
