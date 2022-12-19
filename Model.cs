using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    class Model
    {
        // used to interact with database and has business logic

       public void MainMenu() 
        {
            bool notRunning = true;

            while (!notRunning) 
            {
                Console.WriteLine("MAIN MENU\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Choose from the options below:\n");
                Console.WriteLine("Enter A - to add record");
                Console.WriteLine("Enter V - to view record");
                Console.WriteLine("Enter U - to update a record");
                Console.WriteLine("Enter D - to delete a record");
                Console.WriteLine("Enter Q - to quit/close application");

                string userInput = Console.ReadLine();

                switch (userInput.ToUpper())
                {
                    case 'A':
                        Console.WriteLine("You selected to add a record.\n");

                        break;
                    case 'V':
                        Console.WriteLine("Here are your current records:\n");
                        break;
                    case 'U':
                        Console.WriteLine("Choose the ID of the record you want to update.\n");
                        break;
                    case 'D':
                        Console.WriteLine("What ID of the record you want to delete.\n ");
                        break;
                    case 'Q':
                        notRunning = true;

                }

            }

        }

     

    }
}

