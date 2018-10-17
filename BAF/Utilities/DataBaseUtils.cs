//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;

//namespace BAF.Utilities
//{
//    public class DataBaseUtils
//    {
//        private string connectionstrings = string.Empty;
//        public DataBaseUtils()
//        {

//            connectionstrings = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
//            Console.WriteLine(connectionstrings);
//        }

//        public List<string> ExecuteQuery_DB(string sQuery)
//        {
//            SqlConnection sqlcon = new SqlConnection(connectionstrings);
//            SqlDataReader sqlrd;
//            DataSet ds = new DataSet();
//            SqlCommand cmd = new SqlCommand();
//            try
//            {
//                sqlcon.Open();
//                cmd.CommandText = sQuery;
//                Console.WriteLine(cmd.CommandText);
//                cmd.Connection = sqlcon;

//                //sqlda.SelectCommand.Connection = sqlcon;
//                sqlrd = cmd.ExecuteReader();
//                Console.WriteLine(sqlrd);
//                List<string> lsData = new List<string>();
//                if (sqlrd.HasRows)
//                {
//                    // for (int i = 0; i < sqlrd.FieldCount; i++)
//                    while (sqlrd.Read())
//                    {


//                        lsData.Add(sqlrd[0].ToString());

//                    }
//                    sqlrd.Close();
//                    return lsData;
//                }
//                else
//                {
//                    Console.WriteLine("No rows found.");
//                    sqlrd.Close();
//                    return null;
//                }

//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//            finally
//            {
//                if (sqlcon.State == ConnectionState.Open)
//                {
//                    sqlcon.Close();

//                }
//            }
//        }

//    }
//}
