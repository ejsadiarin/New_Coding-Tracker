using System;
using System.Configuration;

namespace New_Coding_Tracker
{
    class Program
    {
        static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        static void Main(string[] args)
        {
            // instantiate classes

            DatabaseAccess dbAccess = new DatabaseAccess();
            Model model = new Model();
            // add the methods here
            dbAccess.CreateTable(connectionString);
            model.MainMenu();
            
        }
    }
}