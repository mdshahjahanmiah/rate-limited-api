using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.DataObjects.Settings
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public Database SqlServer { get; set; }
    }

    public class Database
    {
        public string Queries { get; set; }
        public string Commands { get; set; }
    }
}
