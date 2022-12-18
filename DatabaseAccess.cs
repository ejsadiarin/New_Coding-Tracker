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
    }
}
