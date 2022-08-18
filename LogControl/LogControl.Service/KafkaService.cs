using Confluent.Kafka;
using LogControl.Model.Interface.Data;
using LogControl.Model.Interface.Service;
using LogControl.Model.Model;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LogControl.Service
{
    public class KafkaService : IKafkaService
    {
        private readonly IKafkaConfig _kafkaConfig;

        public KafkaService(IKafkaConfig ikafkaConfig)
        {
            _kafkaConfig = ikafkaConfig;
        }
    
        public string ConsumerMsg()
        {
            ConsumerConfig conf = new ConsumerConfig
            {
                GroupId = _kafkaConfig.GroupId,
                BootstrapServers = _kafkaConfig.BootstrapServers,
                AutoOffsetReset = _kafkaConfig.AutoOffsetReset
            };

            using var consumerBuilder = new ConsumerBuilder<Ignore, string>(conf).Build();
            {
                consumerBuilder.Subscribe(_kafkaConfig.Topic);
                CancellationTokenSource cts = new CancellationTokenSource();

                try
                {
                    var consumer = consumerBuilder.Consume(cts.Token);
                    return consumer.Message.Value;
                }
                catch (System.Exception ex)
                {
                    consumerBuilder.Close();
                    throw new System.Exception(ex.Message);
                }
            }

          
        }

        public async Task<bool> ProducerMsgAsync(Log log)
        {
            bool status = false;

            string message = JsonSerializer.Serialize(log);
            try
            {
                ProducerConfig config = new ProducerConfig { BootstrapServers = _kafkaConfig.BootstrapServers };
                using var p = new ProducerBuilder<Null,string>(config).Build();
                {
                    var msg = await p.ProduceAsync(_kafkaConfig.Topic, new Message<Null, string> { Value = message });
                }

                status = true;

            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return status;
        }
    }
}
