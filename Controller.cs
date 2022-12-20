using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    public class Controller
    {
        public static List<CodingSession> table = new List<CodingSession>();

        // CRUD CONTROLLER, using methods from UserInput and DatabaseAccess class
        public void AddRecord()
        {
            var date = table[1];
            var startTime = table[2];
            var endTime = table[3];

            // call CalculateDuration method here
            var duration = CalculateDuration(table[4]);

            DatabaseAccess dbAccess = new DatabaseAccess();
            dbAccess.InsertTable(date, startTime, endTime, duration);
        }
        public void ViewRecord()
        {

        }
        public void UpdateRecord()
        {
            // call CalculateDuration method here

        }
        public void DeleteRecord()
        {

        }



        // Calculate duration method here REFACTOR!!!!!!!!!!!!!!!!!!!!!!!!
        public DateTime CalculateDuration(CodingSession t)
        {
            UserInput userInput = new UserInput();
            Validation validation = new Validation();

            DateTime start = userInput.GetTime();
            DateTime end = userInput.GetTime();

            if (end < start)
            {
                Console.WriteLine("End time must be later than start time.");
                return;
            }

            DateTime duration = end - start;
            validation.isDurationNegative(duration);
            
            return duration;
        }
    
    
    }
}
