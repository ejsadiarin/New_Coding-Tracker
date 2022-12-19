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
        public DateTime GetDateInput()
        {
            string dateString = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateString, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            return date;
        }

        public TimeSpan GetStartTime()
        {
            // Format is: Hours:Minutes:Seconds so 00:00:00
            string startTimeString = Console.ReadLine();
            TimeSpan timeStart;
            while (!TimeSpan.TryParse(startTimeString, out timeStart))
            {
                Console.WriteLine("Invalid time format.");
                startTimeString = Console.ReadLine();
            }
            return timeStart;

        }
        public TimeSpan GetEndTime()
        {
            string endTimeString = Console.ReadLine();
            TimeSpan timeEnd;
            while (!TimeSpan.TryParse(endTimeString, out timeEnd))
            {
                Console.WriteLine("Invalid time format.");
                endTimeString = Console.ReadLine();
            }
            return timeEnd;
        }
        


    }
}
