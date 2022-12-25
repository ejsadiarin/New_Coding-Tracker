using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker.Controller
{
    public class CodingController
    {
        // main List table for reference
        internal static List<CodingSession> sessionList = new List<CodingSession>();

        internal static void Add()
        {
            Console.Clear();
            Console.WriteLine("\nYou selected to add a record.");

            // Get date input
            Console.WriteLine("\nAdd a date with format m/d/yyyy (ex. 1/23/2023):");
            string date = UserInput.GetDateInput();

            // Get start time input
            Console.WriteLine("\nAdd a start time with format h:mm tt (ex. 7:07 PM):");
            string startTime = UserInput.GetTime();

            // Get end time input
            Console.WriteLine("\nAdd an end time with format h:mm tt (ex. 7:07 PM):");
            string endTime = UserInput.GetTime();

            // Duration
            Console.WriteLine("mock duration");
            string duration = CalculateDuration(startTime, endTime);

            DatabaseAccess.InsertTable(date, startTime, endTime, duration);

            Console.WriteLine("New row has been added. Hit enter to return to main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void Update()
        {
            Console.Clear();
            DatabaseAccess.ViewTable();
            Console.WriteLine("\nYou selected to update a record.");

            // Get Id
            Console.WriteLine("\nSelect the ID of the record you want to update.");
            string idInput = Console.ReadLine();
            int id = int.Parse(idInput);

            // Check if Id exists on the sessionList
            if (UserInput.DoesIdExist(id))
            {
                /*var getId = UserInput.Find(id);*/
                Console.WriteLine("\nEnter new date with format m/d/yyyy (ex. 1/23/2023):");
                string newDate = UserInput.GetDateInput();
                Console.WriteLine("\nEnter new start time with format h:mm tt (ex. 7:07 PM):");
                string newStart = UserInput.GetTime();
                Console.WriteLine("\nEnter new end time with format h:mm tt (ex. 7:07 PM):");
                string newEnd = UserInput.GetTime();
                Console.WriteLine("\nmock duration");
                string dur = CalculateDuration(newStart, newEnd);

                DatabaseAccess.UpdateTable(id, newDate, newStart, newEnd, dur);
            }
            else
            {
                Console.WriteLine("Id doesn't exist. Please try again.");
                idInput = Console.ReadLine();
            }

            Console.WriteLine("Row has been updated. Hit enter to return to main menu.");
            Console.ReadLine();
            Console.Clear();
            //************ Alternative: Use the Add() and Delete() method, not using the UpdateTable() method ***************//

        }

        internal static void Delete()
        {
            Console.Clear();
            DatabaseAccess.ViewTable();
            Console.WriteLine("\nYou selected to delete a record.");

            // Get Id
            Console.WriteLine("\nSelect the ID of the record you want to delete.");
            string idInput = Console.ReadLine();
            int id = int.Parse(idInput);

            DatabaseAccess.DeleteTable(id);

            Console.WriteLine("Row has been deleted. Hit enter to return to main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void Get()
        {
            Console.Clear();
            DatabaseAccess.ViewTable();
            Console.WriteLine("Hit enter to return to main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        internal static string CalculateDuration(string startTime, string endTime) // return string value "duration"
        {
            TimeSpan start = TimeSpan.ParseExact(startTime, "HH:mm", CultureInfo.InvariantCulture);
            TimeSpan end = TimeSpan.ParseExact(endTime, "HH:mm", CultureInfo.InvariantCulture);
            // validate should be start < end (start before end)
            bool checkTs = Validation.CheckStartIsBeforeEnd(start, end);

            do
            {
                if (checkTs == false)
                {
                    Console.WriteLine("Start time should be earlier than end time");
                    Console.WriteLine("Hit enter to return to main menu.");
                    Console.ReadLine();
                    MainMenu();
                }
                TimeSpan durationTs = end - start;
                string duration = durationTs.ToString();
                return duration;


            } while (checkTs == true);

        }





















        public static void MainMenu()
        {
            DatabaseAccess.CreateTable();
            bool closeApp = false;

            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU\n");
                Console.WriteLine("Welcome to your Coding Tracker!\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Choose from the options below:\n");
                Console.WriteLine("Enter A - to add record");
                Console.WriteLine("Enter V - to view record");
                Console.WriteLine("Enter U - to update a record");
                Console.WriteLine("Enter D - to delete a record");
                Console.WriteLine("Enter Q - to quit/close application");

                string userInput = Console.ReadLine();
                

                // Validate
                while (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("\nInvalid Command. Please type the within the appropriate options.\n");
                    userInput = Console.ReadLine();
                }

                switch (userInput.ToUpper())
                {
                    case "A":
                        Add();    
                        break;
                    
                    case "V":
                        Get();
                        break;

                    case "U":
                        Update();                       
                        break;
                    
                    case "D":
                        Delete();
                        break;

                    case "Q":
                        closeApp = true;
                        break;

                }

            }

        }





    }
}
