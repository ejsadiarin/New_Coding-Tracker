using System;
using System.Collections.Generic;
using ConsoleTableExt;
using New_Coding_Tracker.Controller;

namespace New_Coding_Tracker.Visualization
{
    internal class TableVisualizationEngine
    {
        public static void ShowTableVisualization()
        {
            ConsoleTableBuilder
                .From(CodingController.sessionList)
                .WithTitle("CodingSession")
                .ExportAndWriteLine();
            Console.WriteLine("\n\n");
        }
    }
}