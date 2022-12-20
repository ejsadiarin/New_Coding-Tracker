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
        internal DateTime time;
        /*internal Model model = new Model();*/

        public DateTime GetDateInput()
        {
            Console.WriteLine("Enter the date (Format: MM/dd/yyyy) or enter 0 to go back to the Main Menu: \n");
            string? dateString = Console.ReadLine();

            /*if (dateString == "0") model.MainMenu();*/

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
            Console.WriteLine("Enter the time (Format: HH:mm) or enter 0 to go back to the Main Menu: \n");
            string? timeString = Console.ReadLine();

           /* if (timeString == "0") model.MainMenu();*/

            try
            {
                time = DateTime.ParseExact(timeString, "HH:mm", CultureInfo.InvariantCulture);

            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid time format.");
                timeString = Console.ReadLine();
            }

            return time;

        }


    }
}
