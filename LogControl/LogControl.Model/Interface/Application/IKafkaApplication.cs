
using LogControl.Model.Model;

namespace LogControl.Model.Interface.Application
{
    public interface IKafkaApplication
    {
        public bool ProducerMsg(Log log);
    }
}
