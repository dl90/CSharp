using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Inventory.DB
{
    class Query
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        internal static DataTable PopulateDataTable(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                DataTable dt = new DataTable();
                try
                {
                    SqlCommand users = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(users);
                    da.Fill(dt);
                } 
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
                return dt;
            }
        }
    }
}
