using New_Coding_Tracker.Models;
using System;
using System.Collections.Generic;
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
            DatabaseAccess.ViewTable();
            Console.WriteLine("\nYou selected to add a record.");

            // Get date input
            Console.WriteLine("\nAdd a date:");
            string date = Console.ReadLine();

            // Get start time input
            Console.WriteLine("\nAdd a start time with format H:mm tt (ex. 7:07 PM):");
            string startTime = Console.ReadLine();

            // Get end time input
            Console.WriteLine("\nAdd an end time with format H:mm tt (ex. 7:07 PM):");
            string endTime = Console.ReadLine();

            // Duration
            Console.WriteLine("mock duration");
            string duration = Console.ReadLine();

            DatabaseAccess.InsertTable(date, startTime, endTime, duration);
        }





























        public static void MainMenu()
        {
            DatabaseAccess.CreateTable();
            bool closeApp = false;

            while (closeApp == false)
            {
                Console.WriteLine("MAIN MENU\n");
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
                        DatabaseAccess.ViewTable();
                        
                        break;
                    case "U":
                        
                        break;
                    case "D":
 
                        break;
                    case "Q":
                        closeApp = true;
                        break;

                }

            }

        }





    }
}
