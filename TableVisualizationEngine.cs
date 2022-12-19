using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;
using static New_Coding_Tracker.Controller;

namespace New_Coding_Tracker
{
    internal class TableVisualizationEngine
    {
        public static void CreateTableVisualization()
        {
            ConsoleTableBuilder
                .From(Controller.table)
                .ExportAndWriteLine();
        }
    }
}
