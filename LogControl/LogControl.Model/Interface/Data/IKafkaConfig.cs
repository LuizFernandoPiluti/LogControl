using Confluent.Kafka;

namespace LogControl.Model.Interface.Data
{
    public  interface IKafkaConfig
    {
        public string GroupId { get; set; }
        public string BootstrapServers { get; set; }
        public AutoOffsetReset AutoOffsetReset { get; set; }
        public string Topic { get; set; }

    }
}
