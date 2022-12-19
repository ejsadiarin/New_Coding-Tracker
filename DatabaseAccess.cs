using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;

namespace New_Coding_Tracker
{
    public class DatabaseAccess
    {
        internal static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
        // Create Table
        public static void CreateTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS codingtracker (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Date TEXT,
                        Duration TEXT
                    )";

                tableCmd.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        // Insert Table
        public static void InsertTable(string duration, string startTime, string endTime)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO codingtracker (StartTime, EndTime, Duration) VALUES (@startTime, @endTime, @duration)";
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endTime", endTime);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update Table
        public static void UpdateTable(int id, string startTime, string endTime, string duration)
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
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM codingtracker";
                }
            }
        }



    }
}
