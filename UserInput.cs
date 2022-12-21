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
        internal Model model = new Model();

        public DateTime GetDateInput()
        {
            Console.WriteLine("\nEnter the date (Format: MM/dd/yyyy) or enter 0 to go back to the Main Menu:");
            string? dateString = Console.ReadLine();

            if (dateString == "0") model.MainMenu();

            while (!DateTime.TryParseExact(dateString, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("Invalid date format.");
                dateString= Console.ReadLine();
            }

            return date;
        }

        public DateTime GetTime()
        {
            // Format is: Hours:Minutes:Seconds so 00:00:00
            Console.WriteLine("\nEnter the time (Format: HH:mm:ss) or enter 0 to go back to the Main Menu:");
            string? timeString = Console.ReadLine();

            if (timeString == "0") model.MainMenu();

            while (!DateTime.TryParseExact(timeString, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
            {
                Console.WriteLine("Invalid time format.");
                timeString = Console.ReadLine();
            }

            return time;

        }

        public int GetRowId()
        {
            Validation validation = new Validation();
            bool checkId = true;
            int id;
            do
            {
                id = validation.isNumberEntered();
                checkId = validation.CheckIdExist(id);
            } while (!checkId);

            return id;
        }


    }
}
