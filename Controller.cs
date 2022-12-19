using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    public class Controller
    {
        // CRUD CONTROLLER, using methods from UserInput and DatabaseAccess class
        public void AddRecord()
        {

        }
        public void ViewRecord()
        {

        }
        public void UpdateRecord()
        {

        }
        public void DeleteRecord()
        {

        }



        // Calculate duration method here
        public TimeSpan CalculateDuration()
        {
            UserInput userInput = new UserInput();
            Validation validation = new Validation();

            TimeSpan start = userInput.timeStart;
            TimeSpan end = userInput.timeEnd;
            validation.ValidateTime();
            TimeSpan duration = end - start;
            validation.isDurationNegative(duration);

            return duration;
        }
    
    
    }
}
