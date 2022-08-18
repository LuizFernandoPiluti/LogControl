using LogControl.Model.Interface.Application;
using LogControl.Model.Interface.Service;
using LogControl.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogControl.Application
{
    public  class KafkaApplication: IKafkaApplication
    {
        private readonly IKafkaService _kafkaServicervice;

        public KafkaApplication(IKafkaService kafkaServicervice)
        {
            _kafkaServicervice = kafkaServicervice;
        }
    
        public bool ProducerMsg(Log log)
        {
            return _kafkaServicervice.ProducerMsgAsync(log).Result;
        }
    }
}
