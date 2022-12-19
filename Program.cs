using System;
using System.Configuration;

namespace New_Coding_Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate classes
            Model model = new Model();
            DatabaseAccess dbAccess = new DatabaseAccess();

            // add the methods here
            dbAccess.CreateTable();
            model.MainMenu();


        }
    }
}