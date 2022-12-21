using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    internal class Validation
    {

        // validate endTime should be more than startTime
        public void ValidateTime(DateTime checkStart, DateTime checkEnd)
        {
            if (checkEnd < checkStart)
            {
                Console.WriteLine("End time must be later than start time.");
                return;
            }
        }

        // check if duration is negative
        public bool isDurationNegative(TimeSpan time)
        {
            bool ts = time.Minutes > 0; 
            if (!ts)
            {
                Console.WriteLine("Time cannot be negative.");
            }
                return ts;
        }

        // check if Id exist
        internal CodingSession GetById(int id)
        {
            string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCmd = connection.CreateCommand())
                {
                    connection.Open();

                    tableCmd.CommandText = $"SELECT * FROM coding Where Id = '{id}'";

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
        }

        // check if number is entered
        public int isNumberEntered()
        {
            bool isNumber = true;
            int numberInput;
            string numberString;

            do
            {
                numberString = Console.ReadLine();
                isNumber = int.TryParse(numberString, out numberInput);

                if (!isNumber || numberInput < 0 || string.IsNullOrEmpty(numberString))
                {
                    Console.WriteLine("Number does not exist.");
                    numberString = Console.ReadLine();
                }
            } while (!isNumber || numberInput < 0 || string.IsNullOrEmpty(numberString));

            return numberInput;
        }





    }
}
