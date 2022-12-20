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
        internal string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create Table
        public void CreateTable()
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
        public void UpdateTable(CodingSession id, CodingSession startTime, CodingSession endTime, CodingSession duration)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE codingtracker SET StartTime = @startTime, EndTime = @endTime, Duration = @duration WHERE Id = @id "; // THIS
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endTime", endTime);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Delete Table
        public void DeleteTable(CodingSession id)
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
        public void ViewTable()
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
                                        Duration = reader.GetString(2)
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
        }



    }
}
