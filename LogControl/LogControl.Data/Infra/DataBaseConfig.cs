

using LogControl.Model.Interface.Data;

namespace LogControl.Data.Infra
{
    public class DataBaseConfig : IDataBaseConfig
    {
        public string DataBaseName { get; set; }
        public string ConnecionString { get ; set ; }
    }
}
