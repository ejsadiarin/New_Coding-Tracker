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
        DatabaseAccess dbAccess = new DatabaseAccess();
        UserInput getInput = new UserInput();

        // CRUD CONTROLLER, using methods from UserInput and DatabaseAccess class
        public void AddRecord()
        {
            var date = getInput.GetDateInput();
            var start = getInput.GetTime();
            var end = getInput.GetTime();

            CodingSession codingSession = new CodingSession();

            // Parse DateTime to string
            string? dateString = date.ToString("MM-dd-yyyy");
            string? startString = start.ToString("HH:mm");
            string? endString = end.ToString("HH:mm");

            // Put in CodingSession
            codingSession.Date = dateString;
            codingSession.StartTime = startString;
            codingSession.EndTime = endString;
            // get duration by using CalculateDuration method, that calculates total session time ex. end - start
            // codingSession.Duration = CalculateDuration();

            // Add new values to database
            dbAccess.InsertTable(codingSession);
            
        }
        public void ViewRecord()
        {
            Console.Clear();
            dbAccess.ViewTable();
        }
        public void UpdateRecord()
        {
            // call CalculateDuration method here

        }
        public void DeleteRecord()
        {

        }



      /*  // Calculate duration method here REFACTOR!!!!!!!!!!!!!!!!!!!!!!!!
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
        }*/
    
    
    }
}
