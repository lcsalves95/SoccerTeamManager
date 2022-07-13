using Confluent.Kafka;
using MediatR;
using SoccerTeamManager.Domain.Commands;
using System.Text.Json;

namespace SoccerTeamManager.Api.Services
{
    public static class ProducerKafkaService
    {

        public static async Task<bool> SendMsgStartTimeAsync(InsertEventStartTimeCommand mensagem)
		{
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            var producer = new ProducerBuilder<Null, string>(config).Build();

            using (producer)
            {
                try
                {
                    var result = await producer.ProduceAsync("puc-aws-soccer-start-time",
                                                new Message<Null, string>
                                                {
                                                    Value = JsonSerializer.Serialize(mensagem)
                                                });

                    return true;
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Unexpected error: {e}");

                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unexpected error: {e}");

                    return false;
                }
            }
        }

        public static async Task<bool> SendMsgGoalAsync(InsertEventGoalCommand mensagem)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            var producer = new ProducerBuilder<Null, string>(config).Build();

            using (producer)
            {
                try
                {
                    var result = await producer.ProduceAsync("puc-aws-soccer-goal",
                                                new Message<Null, string>
                                                {
                                                    Value = JsonSerializer.Serialize(mensagem)
                                                });

                    return true;
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Unexpected error: {e}");

                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unexpected error: {e}");

                    return false;
                }
            }
        }

    }
}
