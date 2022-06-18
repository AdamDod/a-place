using System;
using System.Data.SqlClient;

namespace API
{
    public abstract class DatabaseHandler
    {
        public static string GetConnectionString()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "aplace.database.windows.net";
                builder.UserID = "adam";
                builder.Password = "Odsonn1400";
                builder.InitialCatalog = "aplace"; //databsase name
                return builder.ConnectionString;
            }
            catch (Exception e)
            {
                throw new Exception("Error in GetConnectionString(): " + e.Message);
            }
        }
    }
}