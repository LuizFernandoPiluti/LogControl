using LogControl.Model.Model;
using System.Collections.Generic;

namespace LogControl.Model.Interface.Application
{
    public interface ILogApplication
    {
        public List<Log> GetAll();
        public Log Get(string id);
        public bool Insert(Log log);
        public Log Update(string id, Log log);
    }
}
