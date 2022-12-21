using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    public class UserInput
    {
       
        internal Model model = new Model();

        public string GetDateInput()
        {
            Console.WriteLine("\nEnter the date (Format: MM/dd/yyyy) or enter 0 to go back to the Main Menu:");
            string dateString = Console.ReadLine();

            if (dateString == "0") model.MainMenu();

            while (!DateTime.TryParseExact(dateString, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                Console.WriteLine("Invalid date format.");
                dateString= Console.ReadLine();
            }

            return dateString;
        }

        public string GetTime()
        {
            // Format is: Hours:Minutes:Seconds so 00:00:00
            Console.WriteLine("\nEnter the time (Format: HH:mm:ss) or enter 0 to go back to the Main Menu:");
            string? timeString = Console.ReadLine();

            if (timeString == "0") model.MainMenu();
            else
            {
                while (!DateTime.TryParseExact(timeString, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    Console.WriteLine("Invalid time format.");
                    timeString = Console.ReadLine();
                }
            }
            return timeString;

        }

       /* internal CodingSession GetById(int id)
        {
            string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();

                    tableCmd.CommandText = $"SELECT * FROM codingtracker Where Id = '{id}'";

                    using (var reader = tableCmd.ExecuteReader())
                    {
                        CodingSession codingSession = new();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            codingSession.Id = reader.GetInt32(0);
                            codingSession.Date = reader.GetString(1);
                            codingSession.StartTime = reader.GetString(2);
                            codingSession.EndTime = reader.GetString(3);
                            codingSession.Duration = reader.GetString(4);
                        }

                        Console.WriteLine("\n\n");

                        return codingSession;
                    };
                }
            }
        }*/


    }
}
