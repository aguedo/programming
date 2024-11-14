using System.Threading.Channels;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Channel for broadcasting messages
Channel<string> messageChannel = Channel.CreateUnbounded<string>();

// Endpoint for clients to poll for new data
app.MapGet("/poll", async (HttpContext context) =>
{
    // Define a timeout for long polling
    var timeout = TimeSpan.FromSeconds(30);

    // Token to cancel the request if the client disconnects or times out
    using var cancellationTokenSource = new CancellationTokenSource(timeout);
    cancellationTokenSource.Token.Register(() => context.Response.CompleteAsync());

    try
    {
        // Wait for new messages to be written to the channel, or timeout
        if (await messageChannel.Reader.WaitToReadAsync(cancellationTokenSource.Token))
        {
            // If data is available, read it
            var message = await messageChannel.Reader.ReadAsync(cancellationTokenSource.Token);

            // Send the message to the client
            await context.Response.WriteAsJsonAsync(new { message });
        }
        else
        {
            // If no new data, send a "no content" response to indicate no updates
            context.Response.StatusCode = StatusCodes.Status204NoContent;
        }
    }
    catch (OperationCanceledException)
    {
        // Request timed out or client disconnected, send a no-content status
        context.Response.StatusCode = StatusCodes.Status204NoContent;
    }
});

// Endpoint to trigger new data (for example, simulating new data available)
app.MapPost("/send", async (string message) =>
{
    // Write a new message to the channel, notifying all connected clients
    await messageChannel.Writer.WriteAsync(message);
});

app.Run();