using System;
namespace LogControl.Model.Model
{
    public class Log
    {
        public string Id { get; set; }
        public string ApplicationName { get; set; }
        public DateTime LogDate { get; set; }
        public string LogData { get; set; }
        public string Environment { get; set; }
        public string Classification { get; set; }
    }
}
