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
            Console.WriteLine("Start Time:");
            var start = getInput.GetTime();
            Console.WriteLine("End Time:");
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
            codingSession.Duration = CalculateDuration(startString, endString);

            // Add new values to database
            dbAccess.InsertTable(codingSession);
            Console.WriteLine("Your new record has been added successfully!");
        }
        public void ViewRecord()
        {
            Console.Clear();
            dbAccess.ViewTable();
        }
        public void UpdateRecord()
        {
            Console.Clear();
            Console.WriteLine("Select the Id of the record you want to update");
            // call CalculateDuration method here

        }
        public void DeleteRecord()
        {
            Console.Clear();
            Console.WriteLine("Select the Id of the record you want to delete");
        }



        // Calculate duration method here REFACTOR!!!!!!!!!!!!!!!!!!!!!!!!
        public string CalculateDuration(string startTime, string endTime)
        {
            UserInput userInput = new UserInput();
            Validation validation = new Validation();

            // Parse arguments to TimeSpan
            string start = startTime;
            string end = endTime;

            TimeSpan startTs = TimeSpan.Parse(start);
            TimeSpan endTs = TimeSpan.Parse(end);

            // Parse duration TimeSpan (to subtract end - start) to string again for return value
            TimeSpan durationTimeSpan = endTs - startTs;
            string duration = durationTimeSpan.ToString();

            // Validate
            validation.ValidateTime(startTs, endTs);
            validation.isDurationNegative(durationTimeSpan);

            return duration;
        }


    }
}
