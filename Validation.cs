using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    internal class Validation
    {
        internal static UserInput userInput = new UserInput();
        internal TimeSpan start = userInput.timeStart;
        internal TimeSpan end = userInput.timeEnd;

        // validate endTime should be more than startTime
        public void ValidateTime()
        {
            if (end < start)
            {
                Console.WriteLine("End time must be later than start time.");
                return;
            }
        }

        // check if duration is negative
        public void isDurationNegative()
        {
            if (start && end < 0)
            {

            }
        }





    }
}
