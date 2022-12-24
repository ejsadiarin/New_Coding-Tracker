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

        internal static void ValidateTime(DateTime checkStart, DateTime checkEnd)
        {
            if (checkEnd < checkStart)
            {
                Console.WriteLine("End time must be later than start time.");
                return;
            }
        }

        internal static void isDurationNegative(TimeSpan time)
        {
            bool negativeDuration = time.Minutes < 0;
            if (negativeDuration)
            {
                Console.WriteLine("Time cannot be negative.");
                return;
            }
        }






    }
}
