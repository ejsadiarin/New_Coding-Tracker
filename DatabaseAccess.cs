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
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        
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
        public static void InsertTable(string duration, string startTime, string endTime) // need parameters like date, startTime, endTime, etc.
        {
            using (var connection = SqliteConnection(connectionString))
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
        public static void UpdateTable()
        {

        }


        // Delete Table
        public static void DeleteTable()
        {

        }

        // View Table
        public static void ViewTable()
        {

        }



    }
}
