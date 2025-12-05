using ProjectTimestampManager.Models;
using Microsoft.Data.Sqlite;
using ProjectTimestampManager.Helpers;

namespace ProjectTimestampManager.Services
{
    internal class TimeEntryService
    {
        /// <summary>
        /// GetAllProjectTimes - Retrieves all project times from the database (db.project_times).
        /// </summary>
        public List<TimeEntry> GetAllProjectTimes()
        {
            List<TimeEntry> timeEntries = new List<TimeEntry>();
            SqliteConnection connection = DBConnectionHelper.GetConnection();
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Time_Entries";
                SqliteDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    TimeEntry entry = new TimeEntry
                    {
                        Id = reader.GetInt32(0),
                        ProjectId = reader.GetInt32(1),
                        EntryDate = reader.GetDateTime(2),
                        StartTime = reader.GetDateTime(3),
                        EndTime = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                        DurationMinutes = reader.IsDBNull(5) ? null : reader.GetInt32(5)
                    };
                    timeEntries.Add(entry);
                }
                reader.Close();
                return timeEntries;
            }
        }
        /// <summary>
        /// GetProjectTimeById - Retrieves a project time by its ID from the database (db.project_times).
        /// </summary>
        /// <param name="id"></param>
        public TimeEntry? GetProjectTimeById(int id)
        {
            SqliteConnection connection = DBConnectionHelper.GetConnection();
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Time_Entries WHERE id = $id";
                command.Parameters.AddWithValue("$id", id);
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new TimeEntry
                    {
                        Id = reader.GetInt32(0),
                        ProjectId = reader.GetInt32(1),
                        EntryDate = reader.GetDateTime(2),
                        StartTime = reader.GetDateTime(3),
                        EndTime = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                        DurationMinutes = reader.IsDBNull(5) ? null : reader.GetInt32(5)
                    };
                }
                reader.Close();
                return null;
            }
        }
        /// <summary>
        /// GetProjectTimesByProjectId - Retrieves all project times for a specific project ID from the database (db.project_times)
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<TimeEntry> GetProjectTimesByProjectId(int projectId)
        {
            List<TimeEntry> timeEntries = new List<TimeEntry>();
            SqliteConnection connection = DBConnectionHelper.GetConnection();
            try
            {
                using (connection)
                {
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Time_Entries WHERE projectid = $projectId";
                    command.Parameters.AddWithValue("$projectId", projectId);
                    SqliteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TimeEntry entry = new TimeEntry
                        {
                            Id = reader.GetInt32(0),
                            ProjectId = reader.GetInt32(1),
                            EntryDate = reader.GetDateTime(2),
                            StartTime = reader.GetDateTime(3),
                            EndTime = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                            DurationMinutes = reader.IsDBNull(5) ? null : reader.GetInt32(5)
                        };
                        timeEntries.Add(entry);
                    }
                    reader.Close();
                    return timeEntries;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return timeEntries;
            }
        }
        /// <summary>
        /// AddProjectTime - Adds a new project time to the database (db.project_times)
        /// </summary>
        public int AddProjectTime(int projectid, DateTime entrydate, DateTime start, DateTime stop)
        {
            SqliteConnection connection = DBConnectionHelper.GetConnection();
            using (connection)
            {
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Time_Entries (projectid, entry_date, start_time, end_time, duration_minutes) " +
                    "VALUES ($projectid, $entrydate, $start, $stop, $duration)";
                command.Parameters.AddWithValue("$projectid", projectid);
                command.Parameters.AddWithValue("$entrydate", entrydate);
                command.Parameters.AddWithValue("$start", start);
                command.Parameters.AddWithValue("$stop", stop);
                TimeSpan duration = stop - start;
                command.Parameters.AddWithValue("$duration", (int)duration.TotalMinutes);
                command.ExecuteNonQuery();
            }
            return projectid;
        }
        /// <summary>
        /// StartTimeEntry - Starts a time entry for a given project.
        /// </summary>
        /// <param name="entry">A time entry object</param>
        /// <returns>Time Entry</returns>
        public int StartTimeEntry(int projectId)
        {
            try
            {
                SqliteConnection connection = DBConnectionHelper.GetConnection();
                using (connection)
                {
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Time_Entries (projectid, entry_date, start_time) " +
                        "VALUES ($projectid, $entrydate, $start)";
                    command.Parameters.AddWithValue("$projectid", projectId);
                    command.Parameters.AddWithValue("$entrydate", DateTime.Now.Date);
                    command.Parameters.AddWithValue("$start", DateTime.Now);
                    command.ExecuteNonQuery();
                }
                return projectId;
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1;
            }
            
        }
        /// <summary>
        /// StopTimeEntry - Stops the time entry for a given project.
        /// </summary>
        /// <param name="entry">A time entry object</param>
        /// <returns>Time Entry</returns>
        public TimeEntry StopTimeEntry(TimeEntry entry)
        {
            try
            {
                SqliteConnection connection = DBConnectionHelper.GetConnection();
                using (connection)
                {
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE Time_Entries SET end_time = $stop, duration_minutes = $duration " +
                        "WHERE projectid = $projectid AND end_time IS NULL";
                    command.Parameters.AddWithValue("$projectid", entry.ProjectId);
                    command.Parameters.AddWithValue("$stop", DateTime.Now);
                    command.Parameters.AddWithValue("$duration", (int)(DateTime.Now - entry.StartTime).TotalMinutes);
                    command.ExecuteNonQuery();
                }
                return entry;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return entry;
            }
        }
    }
}
