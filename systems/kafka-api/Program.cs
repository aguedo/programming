using Confluent.Kafka;
using System.Collections.Concurrent;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var kafkaConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092", // Kafka broker
    GroupId = "minimal-api-group",       // Consumer group
    AutoOffsetReset = AutoOffsetReset.Earliest, // Start from the earliest if no offset is found
    EnableAutoCommit = true              // Automatically commit offsets
};

IConsumer<Ignore, string> consumer = new ConsumerBuilder<Ignore, string>(kafkaConfig).Build();
var subscribedTopics = new ConcurrentBag<string>();

app.Lifetime.ApplicationStarted.Register(() =>
{
    Task.Run(() =>
    {
        // Subscribe to initial topics
        consumer.Subscribe("test-topic");
        Console.WriteLine("Kafka consumer started.");

        try
        {
            while (true)
            {
                var consumeResult = consumer.Consume();
                Console.WriteLine($"Message: {consumeResult.Value} at {consumeResult.TopicPartitionOffset}");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Kafka consumer stopped.");
        }
        finally
        {
            consumer.Close();
            consumer.Dispose();
        }
    });
});

app.MapPost("/subscribe/{topic}", (string topic) =>
{
    subscribedTopics.Add(topic);
    consumer.Subscribe(subscribedTopics);
    return Results.Ok($"Subscribed to {topic}");
});

app.MapPost("/unsubscribe/{topic}", (string topic) =>
{
    subscribedTopics = new ConcurrentBag<string>(subscribedTopics.Except(new[] { topic }));
    return Results.Ok($"Unsubscribed from {topic}");
});

app.Run();
