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
            string date = getInput.GetDateInput();
            Console.WriteLine("Start Time:");
            string start = getInput.GetTime();
            Console.WriteLine("End Time:");
            string end = getInput.GetTime();

            CodingSession codingSession = new CodingSession();

            // Put in CodingSession
            codingSession.Date = date;
            codingSession.StartTime = start;
            codingSession.EndTime = end;

            // get duration by using CalculateDuration method, that calculates total session time ex. end - start
            codingSession.Duration = CalculateDuration(start, end);

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

            // instantiate CodingSession and UserInput
            CodingSession codingSession = new CodingSession();
            Model model = new Model();
            UserInput userInput = new UserInput();
            
            Console.WriteLine("\nSelect the Id of the record you want to update");

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
                        
                        break;

                    // update start and end times
                    case 2:
                        Console.WriteLine("New start and end time\n");
                        
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
            Console.Clear();
            Console.WriteLine("Changes was updated successfully.");
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

    }
}
