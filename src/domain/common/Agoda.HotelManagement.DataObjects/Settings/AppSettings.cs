using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.DataObjects.Settings
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public RateLimiting RateLimiting { get; set; }
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

    public class RateLimiting 
    {
        public Rule Default { get; set; }
        public List<Rule> Rules { get; set; }
    }

    public class Rule 
    {
        public string Endpoint { get; set; }
        public int Period { get; set; }
        public int Limit { get; set; }
    }
}
