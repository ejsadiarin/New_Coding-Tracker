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
        public void InsertTable(CodingSession codingtracker)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO codingtracker (Date, StartTime, EndTime, Duration) VALUES ('{codingtracker.Date}', '{codingtracker.StartTime}', '{codingtracker.EndTime}', '{codingtracker.Duration}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update Table
        public void UpdateTable(CodingSession codingtracker)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE codingtracker SET Date = '{codingtracker.Date}', StartTime = '{codingtracker.StartTime}', EndTime = '{codingtracker.EndTime}' WHERE Id = {codingtracker.Id}"; 

                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine($"Record Id: {codingtracker.Id} was updated successfully.");
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
