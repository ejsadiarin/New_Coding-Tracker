using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace New_Coding_Tracker
{
    public class DatabaseCreation
    {
        string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
    }
}
