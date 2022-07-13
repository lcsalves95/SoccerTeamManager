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

        public static async Task<bool> SendMsgMinuteBreakAsync(InsertEventMinuteBreakCommand mensagem)
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
                    var result = await producer.ProduceAsync("puc-aws-soccer-minute-break",
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

        public static async Task<bool> SendMsgMinuteAdditionAsync(InsertEventMinuteAdditionCommand mensagem)
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
                    var result = await producer.ProduceAsync("puc-aws-soccer-minute-addition",
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

        public static async Task<bool> SendMsgReplacementAsync(InsertEventReplacementCommand mensagem)
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
                    var result = await producer.ProduceAsync("puc-aws-soccer-replacement",
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

        public static async Task<bool> SendMsgWarningAsync(InsertEventWarningCommand mensagem)
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
                    var result = await producer.ProduceAsync("puc-aws-soccer-warning",
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

        public static async Task<bool> SendMsgEndTimeAsync(InsertEventEndTimeCommand mensagem)
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
                    var result = await producer.ProduceAsync("puc-aws-soccer-end-time",
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
