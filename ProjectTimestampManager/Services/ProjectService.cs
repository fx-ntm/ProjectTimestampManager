using ProjectTimestampManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTimestampManager.Helpers;
using Microsoft.Data.Sqlite;

namespace ProjectTimestampManager.Services
{
    internal class ProjectService
    {
        /// <summary>
        /// GetAllProjects -  Retrieves all projects from the database (db.projects).
        /// </summary>
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            SqliteConnection connection = DBConnectionHelper.GetConnection();
            try
            {
                using (connection)
                {
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM projects";
                    SqliteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            AllocatedHours = reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                    return projects;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return projects;
            }
        }
        /// <summary>
        /// GetProjectById - Retrieves a project by its ID from the database (db.projects).
        /// </summary>
        /// <param name="id"></param>
        public Project? GetProjectById(int id)
        {
            SqliteConnection connection = DBConnectionHelper.GetConnection();
            try
            {
                using (connection)
                {
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM projects WHERE id = $id";
                    command.Parameters.AddWithValue("$id", id);
                    SqliteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return new Project
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            AllocatedHours = reader.GetInt32(2)
                        };
                    }
                    reader.Close();
                    return null;
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
            
        }
        /// <summary>
        /// AddProject - Adds a new project to the database (db.projects)
        /// </summary>
        public void AddProject(string name, int time)
        {
            SqliteConnection connection = DBConnectionHelper.GetConnection();
            try
            {
                using (connection)
                {
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO projects (name, allocated_hours) VALUES ($name, $allocated_hours)";
                    command.Parameters.AddWithValue("$name", name);
                    command.Parameters.AddWithValue("$allocated_hours", time);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}