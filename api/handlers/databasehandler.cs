using System;
using System.Data.SqlClient;

namespace challengeAPI
{
    public abstract class DatabaseHandler
    {
        public static string GetConnectionString()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pracchal.database.windows.net";
                builder.UserID = "jadmash";
                builder.Password = "Skylines33!";
                builder.InitialCatalog = "pracchal"; 
                return builder.ConnectionString;
            }
            catch (Exception e)
            {
                throw new Exception("Error in GetConnectionString(): " + e.Message);
            }
        }
    }
}