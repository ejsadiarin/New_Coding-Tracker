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































        public static void MainMenu()
        {
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
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    userInput = Console.ReadLine();
                }

                switch (userInput.ToUpper())
                {
                    case "A":
                        Console.Clear();
                        Console.WriteLine("You selected to add a record.\n");
                        
                        break;
                    case "V":
                        Console.Clear();
                        Console.WriteLine("Here are your current records:\n");
                        
                        break;
                    case "U":
                        
                        break;
                    case "D":
                        Console.Clear();
                        Console.WriteLine("What ID of the record you want to delete.\n ");
                        break;
                    case "Q":
                        closeApp = true;
                        break;

                }

            }

        }





    }
}
