
using LogControl.Model.Interface.Data;
using LogControl.Model.Interface.Service;
using LogControl.Model.Model;
using System.Collections.Generic;

namespace LogControl.Service
{

    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public Log Get(string id)
        {
           return _logRepository.Get(id);
        }

        public List<Log> GetAll()
        {
            return _logRepository.GetAll();
        }

        public bool Insert(Log log)
        {
           return _logRepository.Insert(log);
        }

        public Log Update(string id, Log log)
        {
            return _logRepository.Update(id, log);  
        }
    }
}
