using System;
using System.Collections.Generic;
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

            while (!DateTime.TryParseExact(timeString, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                Console.WriteLine("Invalid time format.");
                timeString = Console.ReadLine();
            }

            return timeString;

        }


    }
}
