using System;
using System.Configuration;
using New_Coding_Tracker.Controller;

namespace New_Coding_Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // call static MainMenu() method from Controller
            CodingController.MainMenu();
            
        }
    }
}