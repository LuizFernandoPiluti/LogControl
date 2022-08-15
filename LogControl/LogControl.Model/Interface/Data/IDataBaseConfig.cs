using System;
using System.Collections.Generic;
using System.Text;

namespace LogControl.Model.Interface.Data
{
    public interface IDataBaseConfig
    {
        public string DataBaseName { get; set; }
        public string ConnecionString { get; set; }
    }
}
