using Confluent.Kafka;
using Newtonsoft.Json;
using SoccerTeamManager.Infra.Messages;

namespace SoccerTeamManager.Infra.KafkaSettings
{
    public class ProducerWrapper
    {
        private readonly IProducer<string, string> _producer;

        public ProducerWrapper(ProducerBuilder<string, string> builder)
        {
            _producer = builder.Build();
        }

        public async Task WriteMessage(string topic, IEvent message)
        {
            var dr = await _producer.ProduceAsync(topic, new Message<string, string>()
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonConvert.SerializeObject(message)
            });
            Console.WriteLine($"KAFKA => Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
            return;
        }
    }
}
