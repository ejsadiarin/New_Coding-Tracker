using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;
using static New_Coding_Tracker.CodingSession;

namespace New_Coding_Tracker
{
    public class DatabaseAccess
    {
        internal string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        // Create Table
        public void CreateTable(string connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS codingtracker (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Date TEXT,
                        StartTime TEXT,
                        EndTime TEXT,
                        Duration TEXT
                    )";

                tableCmd.ExecuteNonQuery();
                
            }
        }

        // Insert Table
        public void InsertTable(CodingSession codingSession)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO codingtracker (Date, StartTime, EndTime, Duration) VALUES ('{codingSession.Date}', '{codingSession.StartTime}', '{codingSession.EndTime}', '{codingSession.Duration}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update Table
        public void UpdateTableDate(int id, string date)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE codingtracker SET Date = @date WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateTableTime(int id, string startTime, string endTime, string duration)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE codingtracker SET StartTime = @startTime, EndTime = @endTime, Duration = @duration WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endTime", endTime);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Delete Table
        public void DeleteTable(int id)
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
        public List<CodingSession> ViewTable()
        {
            List<CodingSession> tableData = new List<CodingSession>();
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
                                // Add to the tableData List, that references to CodingSession class' necessary properties
                                tableData.Add(
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
            TableVisualizationEngine.ShowTableVisualization(tableData);

            return tableData;

        }



    }
}
