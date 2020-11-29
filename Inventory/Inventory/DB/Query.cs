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
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        internal static DataTable PopulateDataTable(string query, (string, dynamic)[] args)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                DataTable dt = new DataTable();
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    foreach ((string, dynamic) arg in args)
                    {
                        cmd.Parameters.AddWithValue(arg.Item1, arg.Item2);
                    }
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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


        internal static int InsertUpdateDeleteQuery(string query, (string, dynamic)[] args)
        {
            if (args.Length == 0) return 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    foreach ((string, dynamic) arg in args) 
                    {
                        cmd.Parameters.AddWithValue(arg.Item1, arg.Item2);
                    }
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
