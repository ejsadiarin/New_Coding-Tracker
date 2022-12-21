using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    public class Controller
    {
        public List<CodingSession> table = new List<CodingSession>();
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
            Console.WriteLine("Your new record has been added successfully!\n\n");
        }
        public void ViewRecord()
        {
            Console.Clear();
            dbAccess.ViewTable();
        }
        public void UpdateRecord()
        {
            Console.Clear();
            ViewRecord();
            Console.WriteLine("\nSelect the Id of the record you want to update");
            string idString = Console.ReadLine();
            int id = Convert.ToInt32(idString);
            // add Id validation here -> if Id exists

            // instantiate CodingSession and UserInput
            CodingSession codingSession = new CodingSession();
            Model model = new Model();
            UserInput userInput = new UserInput();

            // create while loop for continous updating process until updateProcess evaluates to false
            bool updateProcess = true;

            while (updateProcess)
            {
                // call UpdateMenu()
                model.UpdateMenu();
                string choiceString = Console.ReadLine();
                int choice = Convert.ToInt32(choiceString);

                // switch cases w/ .ToUpper()
                switch (choice)
                {
                    // update date
                    case 1:
                        Console.WriteLine("New date");
                        DateTime newDate = userInput.GetDateInput();
                        // Parse newDate to string
                        string dateString = newDate.ToString();
                        // Set new value of date
                        codingSession.Date = dateString;
                        break;

                    // update start
                    case 2:
                        Console.WriteLine("New start and end time");
                        CalculateDurationForUpdate();
                        break;

                    // save changes
                    case 3:
                        updateProcess = false;
                        break;

                    // go back to main menu
                    case 0:
                        model.MainMenu();
                        updateProcess = false;
                        break;
                    // if not in choices
                    default:
                        Console.WriteLine("Invalid option.");
                        choiceString = Console.ReadLine();
                        break;
                }
            }
            dbAccess.UpdateTable(codingSession);
            model.MainMenu();

        }
        public void DeleteRecord()
        {
            Console.Clear();
            ViewRecord();
            Console.WriteLine("\nSelect the Id of the record you want to delete");
            string idString = Console.ReadLine();
            int id = Convert.ToInt32(idString);
            // add Validation if Id not exists, then "The record of id doesn't exist"
            dbAccess.DeleteTable(id);

        }



        // Calculate duration method here
        public string CalculateDuration(string startTime, string endTime)
        {
            UserInput userInput = new UserInput();
            Validation validation = new Validation();

            // Parse arguments to TimeSpan
            string start = startTime;
            string end = endTime;
            
            DateTime startTs = DateTime.Parse(start);
            DateTime endTs = DateTime.Parse(end);

            // Parse duration TimeSpan (to subtract end - start) to string again for return value
            TimeSpan durationTimeSpan = endTs.TimeOfDay - startTs.TimeOfDay;
            string duration = durationTimeSpan.ToString();

            // Validate
            validation.ValidateTime(startTs, endTs);
            validation.isDurationNegative(durationTimeSpan);

            return duration;
        }

        public List<string> CalculateDurationForUpdate()
        {
            List<string> timeList = new List<string>();
            UserInput userInput = new UserInput();
            Validation validation = new Validation();

            DateTime newStart, newEnd;
            TimeSpan durationTimeSpan;
            bool isNegative;
            string startString, endString, duration;

            do
            {
                newStart = userInput.GetTime();
                newEnd = userInput.GetTime();

                durationTimeSpan = newEnd - newStart;

                // Parse all to string
                duration = durationTimeSpan.ToString();
                startString = newStart.ToString();
                endString = newEnd.ToString();

                isNegative = validation.isDurationNegative(durationTimeSpan);
            }
            while (!isNegative);

            timeList.Add(startString);
            timeList.Add(endString);
            timeList.Add(duration);
            return timeList;
        }
    }
}
