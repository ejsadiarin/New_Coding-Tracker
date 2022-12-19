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
        public void ValidateTime()
        {
            UserInput userInput = new UserInput();
            TimeSpan start = userInput.timeStart;
            TimeSpan end = userInput.timeEnd;
            if (end < start)
            {
                Console.WriteLine("End time must be later than start time.");
                return;
            }
        }
    }
}
