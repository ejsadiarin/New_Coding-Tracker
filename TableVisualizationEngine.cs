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
        public void CreateTableVisualization()
        {
            ConsoleTableBuilder
                .From(Controller.table)
                .ExportAndWriteLine();
        }
    }
}
