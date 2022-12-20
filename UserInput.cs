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
        internal DateTime date;

        public DateTime GetDateInput()
        {
            Console.WriteLine("Format: MM/dd/yyyy");
            string? dateString = Console.ReadLine();
            while (DateTime.TryParseExact(dateString, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("Invalid date format.");
                dateString= Console.ReadLine();
            }

            return date;
        }

        public DateTime GetTime()
        {
            // Format is: Hours:Minutes:Seconds so 00:00:00
            string time = Console.ReadLine();

            while (!DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
            {
                Console.WriteLine("Invalid time format.");
                time = Console.ReadLine();
            }
            return timeStart;

        }


    }
}
