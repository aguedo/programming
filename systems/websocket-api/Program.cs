using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();

HashSet<WebSocket> _webSockets = []; // TODO: fix concurrency.

app.Map("/chat", async (HttpContext context) =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        await EchoMessages(webSocket);
    }
    else
    {
        context.Response.StatusCode = 400;
    }
});

app.Run();

async Task EchoMessages(WebSocket webSocket)
{
    _webSockets.Add(webSocket);
    var buffer = new byte[1024 * 4];
    WebSocketReceiveResult result;
    do
    {
        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        if (result.MessageType == WebSocketMessageType.Text)
        {
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine($"Received: {message}");

            await Broadcast(message, webSocket);
        }
    }
    while (!result.CloseStatus.HasValue);

    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
}

async Task Broadcast(string message, WebSocket source)
{
    var echoBytes = Encoding.UTF8.GetBytes(message);
    foreach (WebSocket webSocket in _webSockets)
    {
        if (webSocket.State != WebSocketState.Open)
        {
            _webSockets.Remove(webSocket);
            continue;
        }

        if (webSocket != source)
        {
            await webSocket.SendAsync(new ArraySegment<byte>(echoBytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
