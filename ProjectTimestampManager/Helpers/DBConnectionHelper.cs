using Microsoft.Data.Sqlite;

namespace ProjectTimestampManager.Helpers
{
    internal class DBConnectionHelper
    {
        /// <summary>
        /// Gets the full path to the DB file
        /// </summary>
        private static string GetDatabasePath()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(appDirectory, "database.db");
        }

        /// <summary>
        /// Gets an open SQLite connection to the database
        /// </summary>
        /// <returns>An open SqliteConnection</returns>
        public static SqliteConnection GetConnection()
        {
            string dbPath = GetDatabasePath();
            string connectionString = $"Data Source={dbPath}";
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
