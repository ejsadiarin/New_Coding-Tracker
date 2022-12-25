using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;
using New_Coding_Tracker.Visualization;
using New_Coding_Tracker.Controller;
using System.Reflection;

namespace New_Coding_Tracker
{
    public class DatabaseAccess
    {
        internal static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        // Create Table
        public static void CreateTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS codingtracker (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Date TEXT,
                        StartTime TEXT,
                        EndTime TEXT,
                        Duration TEXT
                    )";

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Insert Table
        public static void InsertTable(string date, string startTime, string endTime, string duration)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO codingtracker (Date, StartTime, EndTime, Duration) VALUES (@date, @startTime, @endTime, @duration)";
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endTime", endTime);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update Table
        public static void UpdateTable(int id, string date, string startTime, string endTime, string duration)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE codingtracker SET 
                                            Date = @date, 
                                            StartTime = @startTime,
                                            EndTime = @endTime,
                                            Duration = @duration 
                                        WHERE 
                                            Id = @id
                                        ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endTime", endTime);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Delete Table
        public static void DeleteTable(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM codingtracker WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // View Table
        public static void ViewTable()
        {

            using (var connection = new SqliteConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM codingtracker";

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Add to the List, that references to CodingSession class' necessary properties
                                CodingController.sessionList.Add(
                                    new CodingSession
                                    {
                                        Id = reader.GetInt32(0),
                                        Date = reader.GetString(1),
                                        StartTime = reader.GetString(2),
                                        EndTime = reader.GetString(3),
                                        Duration = reader.GetString(4)
                                    });
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.\n");
                        }
                    }
                }
            }

            TableVisualizationEngine.ShowTableVisualization();

        }



    }
}