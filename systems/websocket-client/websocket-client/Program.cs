using System.Net.WebSockets;
using System.Text;

var serverUri = new Uri("ws://localhost:5190/chat");
using var client = new ClientWebSocket();

Console.WriteLine("Connecting to WebSocket server...");
await client.ConnectAsync(serverUri, CancellationToken.None);
Console.WriteLine("Connected!");

// Start sending and receiving messages
await Task.WhenAll(ReceiveMessages(client), SendMessages(client));

static async Task SendMessages(ClientWebSocket client)
{
    while (client.State == WebSocketState.Open)
    {
        Console.Write("Enter message to send: ");
        string message = Console.ReadLine();
        var messageBytes = Encoding.UTF8.GetBytes(message);
        var buffer = new ArraySegment<byte>(messageBytes);

        await client.SendAsync(buffer, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
        Console.WriteLine($"Sent: {message}");
    }
}

static async Task ReceiveMessages(ClientWebSocket client)
{
    var buffer = new byte[1024 * 4];
    while (client.State == WebSocketState.Open)
    {
        var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        if (result.MessageType == WebSocketMessageType.Text)
        {
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine();
            Console.WriteLine($"Received: {message}");
        }
        else if (result.MessageType == WebSocketMessageType.Close)
        {
            Console.WriteLine("Server closed connection");
            await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
        }
    }
}