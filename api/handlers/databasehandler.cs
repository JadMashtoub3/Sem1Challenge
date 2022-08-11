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
                builder.DataSource = "sem1challenge.database.windows.net";
                builder.UserID = "jad";
                builder.Password = "Skylines33!";
                builder.InitialCatalog = "sem1challenge"; 
                return builder.ConnectionString;
            }
            catch (Exception e)
            {
                throw new Exception("Error in GetConnectionString(): " + e.Message);
            }
        }
    }
}