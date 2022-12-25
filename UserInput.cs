using Microsoft.Data.Sqlite;
using New_Coding_Tracker.Controller;
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
        internal static string GetDateInput()
        {
            string dateString = Console.ReadLine();

            if (dateString == "0")
            {
                Console.Clear();
                CodingController.MainMenu();
            }

            while (!DateTime.TryParseExact(dateString, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                Console.WriteLine("Invalid date format.");
                dateString = Console.ReadLine();
            }

            return dateString;
        }

        internal static string GetTime()
        {
            string timeString = Console.ReadLine();

            if (timeString == "0")
            {
                Console.Clear();
                CodingController.MainMenu();
            }
            else
            {
                while (!DateTime.TryParseExact(timeString, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    Console.WriteLine("Invalid time format.");
                    timeString = Console.ReadLine();
                }
            }
            return timeString;

        }

        internal static bool DoesIdExist(int id)
        {
            return CodingController.sessionList.Any(item => item.Id == id);
        }

        internal static CodingSession Find(int id)
        {
            return CodingController.sessionList.FirstOrDefault(item => item.Id == id);
        }



    }
}