using LogControl.Model.Model;
using System.Threading.Tasks;

namespace LogControl.Model.Interface.Service
{
    public interface IKafkaService
    {
        Task<bool> ProducerMsgAsync(Log log);
        string ConsumerMsg();

    }
}
