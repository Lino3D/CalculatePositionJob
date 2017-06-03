using SQLPositionFinder.DataObjects;
using SQLPositionFinder.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLPositionFinder.Processors
{
    class SQLRunner
    {
        string ConnectionString;
        public SQLRunner()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["mainCS"].ToString();
        }

        // Ta funkcja zwróci w liście tylko pary
        public List<DataFloorPoint> GetFloorCountForPairData(IBssidData data, int MaxDistance)
        {
            List<DataFloorPoint> RetFloor = new List<DataFloorPoint>();
            //Person matchingPerson = new Person();
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                Query query = new Query(data, MaxDistance);

                string oString = query.GetQueryForFloorCountPair();


                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                try
                {
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            RetFloor.Add(new DataFloorPoint(oReader.GetString(1), oReader.GetInt32(0)));
                        }

                        myConnection.Close();
                    }
                }
                catch (Exception e)
                {
                    return RetFloor;
                }
            }

            return RetFloor;
        }

        // Ta funkcja zwróci w liście wszystko, wszystko
        public List<string> GetFloorCountForWholeList(IBssidData data, int MaxDistance)
        {
            List<string> RetFloor = new List<string>();
            //Person matchingPerson = new Person();
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                Query query = new Query(data,MaxDistance);
                
                string oString = query.GetQueryForWholeList();
                SqlCommand oCmd = new SqlCommand(oString, myConnection);                
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        // Floor parameters is on the second place in sql query
                        RetFloor.Add(oReader.GetString(1));
                    }

                    myConnection.Close();
                }
            }

            return RetFloor;
        }
    }
}
