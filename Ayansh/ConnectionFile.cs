using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayansh
{
    public static class ConnectionFile
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
        }

        public static DataSet RetunDataFromDatabase()
        {
            string sql = "select top 600 order_id, customer_id,order_status,store_id,staff_id from sales.orders "+
                " select top 600  store_id + staff_id as storestaff from sales.orders";
            
            DataSet ds = new DataSet();

            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(sql, conn);
                        da.SelectCommand.CommandType = CommandType.Text;

                        da.Fill(ds, "DataSetResult");

                        return ds;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return ds;
            }
        }
    }
}
