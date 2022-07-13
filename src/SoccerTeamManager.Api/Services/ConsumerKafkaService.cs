using Confluent.Kafka;
using MediatR;
using SoccerTeamManager.Domain.Commands;
using System.Text.Json;

namespace SoccerTeamManager.Api.Services
{
    public class ConsumerKafkaService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ConsumerKafkaService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => StartMsgStartTimeAsync(cancellationToken));
            Task.Run(() => StartMsgGoalAsync(cancellationToken));
            Task.Run(() => StartMsgMinuteBreakAsync(cancellationToken));
            Task.Run(() => StartMsgMinuteAdditionAsync(cancellationToken));
            Task.Run(() => StartMsgReplacementAsync(cancellationToken));
            Task.Run(() => StartMsgWarningAsync(cancellationToken));
            Task.Run(() => StartMsgEndTimeAsync(cancellationToken));
        }

        public async Task StartMsgStartTimeAsync(CancellationToken cancellationToken)
		{
            var configStartTime = new ConsumerConfig
            {
                GroupId = "puc-aws-soccer-start-time-group-0",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(configStartTime).Build())
            {
                consumer.Subscribe("puc-aws-soccer-start-time");

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var cr = consumer.Consume(cancellationToken);
                        var json = cr.Message.Value;
                        var command = JsonSerializer.Deserialize<InsertEventStartTimeCommand>(json);

                        using var scope = _serviceScopeFactory.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var requestResult = await mediator.Send(command);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ConsumeException e)
                    {
                        // Consumer errors should generally be ignored (or logged) unless fatal.  
                        Console.WriteLine($"Consume error: {e.Error.Reason}");

                        if (e.Error.IsFatal)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected error: {e}");

                        await StartMsgStartTimeAsync(cancellationToken);
                    }
                }
            }           
        }

        public async Task StartMsgGoalAsync(CancellationToken cancellationToken)
        {
            var configStartTime = new ConsumerConfig
            {
                GroupId = "puc-aws-soccer-goal-group-0",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(configStartTime).Build())
            {
                consumer.Subscribe("puc-aws-soccer-goal");

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var cr = consumer.Consume(cancellationToken);
                        var json = cr.Message.Value;
                        var command = JsonSerializer.Deserialize<InsertEventGoalCommand>(json);

                        using var scope = _serviceScopeFactory.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var requestResult = await mediator.Send(command);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ConsumeException e)
                    {
                        // Consumer errors should generally be ignored (or logged) unless fatal.  
                        Console.WriteLine($"Consume error: {e.Error.Reason}");

                        if (e.Error.IsFatal)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected error: {e}");

                        await StartMsgGoalAsync(cancellationToken);
                    }
                }
            }
        }

        public async Task StartMsgMinuteBreakAsync(CancellationToken cancellationToken)
        {
            var configStartTime = new ConsumerConfig
            {
                GroupId = "puc-aws-soccer-minute-break-group-0",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(configStartTime).Build())
            {
                consumer.Subscribe("puc-aws-soccer-minute-break");

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var cr = consumer.Consume(cancellationToken);
                        var json = cr.Message.Value;
                        var command = JsonSerializer.Deserialize<InsertEventMinuteBreakCommand>(json);

                        using var scope = _serviceScopeFactory.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var requestResult = await mediator.Send(command);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ConsumeException e)
                    {
                        // Consumer errors should generally be ignored (or logged) unless fatal.  
                        Console.WriteLine($"Consume error: {e.Error.Reason}");

                        if (e.Error.IsFatal)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected error: {e}");

                        await StartMsgGoalAsync(cancellationToken);
                    }
                }
            }
        }

        public async Task StartMsgMinuteAdditionAsync(CancellationToken cancellationToken)
        {
            var configStartTime = new ConsumerConfig
            {
                GroupId = "puc-aws-soccer-minute-addition-group-0",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(configStartTime).Build())
            {
                consumer.Subscribe("puc-aws-soccer-minute-addition");

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var cr = consumer.Consume(cancellationToken);
                        var json = cr.Message.Value;
                        var command = JsonSerializer.Deserialize<InsertEventMinuteAdditionCommand>(json);

                        using var scope = _serviceScopeFactory.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var requestResult = await mediator.Send(command);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ConsumeException e)
                    {
                        // Consumer errors should generally be ignored (or logged) unless fatal.  
                        Console.WriteLine($"Consume error: {e.Error.Reason}");

                        if (e.Error.IsFatal)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected error: {e}");

                        await StartMsgGoalAsync(cancellationToken);
                    }
                }
            }
        }

        public async Task StartMsgReplacementAsync(CancellationToken cancellationToken)
        {
            var configStartTime = new ConsumerConfig
            {
                GroupId = "puc-aws-soccer-replacement-group-0",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(configStartTime).Build())
            {
                consumer.Subscribe("puc-aws-soccer-replacement");

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var cr = consumer.Consume(cancellationToken);
                        var json = cr.Message.Value;
                        var command = JsonSerializer.Deserialize<InsertEventReplacementCommand>(json);

                        using var scope = _serviceScopeFactory.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var requestResult = await mediator.Send(command);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ConsumeException e)
                    {
                        // Consumer errors should generally be ignored (or logged) unless fatal.  
                        Console.WriteLine($"Consume error: {e.Error.Reason}");

                        if (e.Error.IsFatal)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected error: {e}");

                        await StartMsgGoalAsync(cancellationToken);
                    }
                }
            }
        }

        public async Task StartMsgWarningAsync(CancellationToken cancellationToken)
        {
            var configStartTime = new ConsumerConfig
            {
                GroupId = "puc-aws-soccer-warning-group-0",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(configStartTime).Build())
            {
                consumer.Subscribe("puc-aws-soccer-warning");

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var cr = consumer.Consume(cancellationToken);
                        var json = cr.Message.Value;
                        var command = JsonSerializer.Deserialize<InsertEventWarningCommand>(json);

                        using var scope = _serviceScopeFactory.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var requestResult = await mediator.Send(command);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ConsumeException e)
                    {
                        // Consumer errors should generally be ignored (or logged) unless fatal.  
                        Console.WriteLine($"Consume error: {e.Error.Reason}");

                        if (e.Error.IsFatal)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected error: {e}");

                        await StartMsgGoalAsync(cancellationToken);
                    }
                }
            }
        }

        public async Task StartMsgEndTimeAsync(CancellationToken cancellationToken)
        {
            var configStartTime = new ConsumerConfig
            {
                GroupId = "puc-aws-soccer-end-time-group-0",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(configStartTime).Build())
            {
                consumer.Subscribe("puc-aws-soccer-end-time");

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var cr = consumer.Consume(cancellationToken);
                        var json = cr.Message.Value;
                        var command = JsonSerializer.Deserialize<InsertEventEndTimeCommand>(json);

                        using var scope = _serviceScopeFactory.CreateScope();
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var requestResult = await mediator.Send(command);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ConsumeException e)
                    {
                        // Consumer errors should generally be ignored (or logged) unless fatal.  
                        Console.WriteLine($"Consume error: {e.Error.Reason}");

                        if (e.Error.IsFatal)
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Unexpected error: {e}");

                        await StartMsgStartTimeAsync(cancellationToken);
                    }
                }
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
        }

    }
}
