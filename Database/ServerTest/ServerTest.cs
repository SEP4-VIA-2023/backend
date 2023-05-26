using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace ServerTest
{
    public class WebSocketServer
    {
        private readonly HttpListener _listener;

        public WebSocketServer(string url)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(url);
            _listener.Start();
        }

        public async Task Start()
        {
            

            while (true)
            {
                var context = await _listener.GetContextAsync();
                if (!context.Request.IsWebSocketRequest)
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                    continue;
                }

                var webSocketContext = await context.AcceptWebSocketAsync(null);
                Console.WriteLine("WebSocket connected");

                // start a new thread to handle the WebSocket
                var thread = new Thread(() => HandleWebSocket(webSocketContext.WebSocket));
                thread.Start();
            }
        }

        private async void HandleWebSocket(WebSocket webSocket)
        {
            try
            {
                var buffer = new byte[4096];
                while (webSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        Console.WriteLine($"Received message: {message}");

                        // echo the message back to the client
                        await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebSocket error: {ex.Message}");
            }
            finally
            {
                webSocket.Dispose();
                Console.WriteLine("WebSocket disconnected");
            }
        }

    }
}
