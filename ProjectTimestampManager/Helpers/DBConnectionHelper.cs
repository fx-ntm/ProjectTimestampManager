using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ProjectTimestampManager.Helpers
{
    internal class DBConnectionHelper
    {
        private const string connectionString = "Data Source=database.db";
        public static SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
