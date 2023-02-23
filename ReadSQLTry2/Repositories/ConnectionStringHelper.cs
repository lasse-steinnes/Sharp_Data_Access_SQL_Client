using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadSQLTry2.Repositories
{
    public class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "N-NO-01-01-6706"; // "sqlServerNAMe
            builder.InitialCatalog = "Chinook"; // database name
            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;

            // Check
            Console.WriteLine(builder.ConnectionString);

            return builder.ConnectionString;
        }
    }
}
