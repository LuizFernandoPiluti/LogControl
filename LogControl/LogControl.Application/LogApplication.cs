using LogControl.Model.Interface.Application;
using LogControl.Model.Interface.Service;
using LogControl.Model.Model;
using System.Collections.Generic;

namespace LogControl.Application
{
    public class LogApplication:ILogApplication
    {
        private readonly ILogService _logService;
        public LogApplication(ILogService logService)
        {
            _logService = logService;
        }

        public Log Get(string id)
        {
            return _logService.Get(id);
        }

        public List<Log> GetAll()
        {
            return _logService.GetAll();    
        }

        public bool Insert(Log log)
        {
            return _logService.Insert(log); 
        }

        public Log Update(string id, Log log)
        {
            return _logService.Update(id, log);
        }
    }
}
