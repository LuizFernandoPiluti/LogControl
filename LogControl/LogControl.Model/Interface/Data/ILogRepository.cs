using LogControl.Model.Model;
using System.Collections.Generic;

namespace LogControl.Model.Interface.Data
{
    public interface ILogRepository
    {
        public List<Log> GetAll();
        public Log Get(string id);
        public bool Insert(Log log);
        public Log Update(string id, Log log);    
    }
}
