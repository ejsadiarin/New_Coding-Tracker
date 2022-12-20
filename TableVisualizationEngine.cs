using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;
using New_Coding_Tracker;

namespace New_Coding_Tracker
{
    internal class TableVisualizationEngine
    {
        public static void ShowTableVisualization<T>(List<T> tableData) where T : class
        {
            ConsoleTableBuilder
                .From(tableData)
                .WithTitle("CodingSession")
                .ExportAndWriteLine();
            Console.WriteLine("\n\n");
        }
    }
}
