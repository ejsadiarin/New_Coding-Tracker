using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    internal class Validation
    {

        // validate endTime should be more than startTime
        public void ValidateTime(TimeSpan checkStart, TimeSpan checkEnd)
        {
            if (checkEnd < checkStart)
            {
                Console.WriteLine("End time must be later than start time.");
                return;
            }
        }

        // check if duration is negative
        public void isDurationNegative(TimeSpan time)
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
