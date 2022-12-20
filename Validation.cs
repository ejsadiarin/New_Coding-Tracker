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
     /*   public void ValidateTime()
        {
            if (end < start)
            {
                Console.WriteLine("End time must be later than start time.");
                return;
            }
        }*/

        // check if duration is negative
        public bool isDurationNegative(TimeSpan time)
        {
            bool PositiveTime = time.Minutes > 0; 
            if (!PositiveTime)
            {
                Console.WriteLine("Time cannot be negative.");
            }
            return PositiveTime;
        }





    }
}
