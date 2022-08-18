using Confluent.Kafka;
using LogControl.Model.Interface.Data;

namespace LogControl.Kafka
{
    public class KafkaConfig : IKafkaConfig
    {
        public string GroupId { get; set; }
        public string BootstrapServers { get; set ; }
        public AutoOffsetReset AutoOffsetReset { get; set; }
        public string Topic { get; set; }

        public KafkaConfig()
        {
            GroupId = "log-consumer-group";
            BootstrapServers = "127.0.0.1:9092";
            AutoOffsetReset = AutoOffsetReset.Earliest;
            Topic = "log-topic"; 
        }
        
      


        public ConsumerConfig GetConfig()
        {

            var conf = new ConsumerConfig
            {
                GroupId = GroupId ,
                BootstrapServers = BootstrapServers,
                AutoOffsetReset = AutoOffsetReset
            };

            return conf;
        }
    }
}
