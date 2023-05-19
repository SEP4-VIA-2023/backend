using System;
using System.Net.WebSockets;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace WebSockets
{
    public class WebsocketClient
    {
        private ClientWebSocket _webSocket;
        private CancellationTokenSource _cancellationTokenSource;

        public WebsocketClient(string url)
        {
            _webSocket = new ClientWebSocket();
            _cancellationTokenSource = new CancellationTokenSource();

            ConnectAsync(url).Wait();
        }

        private async Task ConnectAsync(string url)
        {
            try
            {
                await _webSocket.ConnectAsync(new Uri(url), CancellationToken.None);
                await OnOpenAsync();
                await ReceiveLoopAsync();
            }
            catch (Exception ex)
            {
                await OnErrorAsync(ex);
            }
            finally
            {
                if (_webSocket.State != WebSocketState.Closed)
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by client", CancellationToken.None);
                _webSocket.Dispose();
            }
        }

        public async Task SendDownLink(string jsonTelegram)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(jsonTelegram);
            await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task ReceiveLoopAsync()
        {
            var buffer = new byte[1024];
            while (_webSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    await OnMessageReceivedAsync(data);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await OnCloseAsync(result.CloseStatus.GetValueOrDefault(), result.CloseStatusDescription);
                    break;
                }
            }
        }

        private async Task OnOpenAsync()
        {
            await _webSocket.SendAsync(new byte[1], WebSocketMessageType.Text, true, CancellationToken.None);
            Console.WriteLine("WebSocket connection has been opened.");
            // Add any custom logic you need upon successful connection
        }

        private async Task OnMessageReceivedAsync(string message)
        {
            Console.WriteLine("Received message: " + message);

            // Assuming the incoming message is a string of hexadecimal values without any delimiter
            // Example: "A1B4F8C2"
    
            // Convert the hexadecimal string to a byte array
            byte[] bytes = new byte[message.Length / 2];
            for (int i = 0; i < message.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(message.Substring(i, 2), 16);
            }

            // Convert the byte array to numbers based on your data format
            // For example, if each reading consists of two bytes representing a 16-bit unsigned integer
            for (int i = 0; i < bytes.Length; i += 2)
            {
                ushort value = BitConverter.ToUInt16(bytes, i);
                Console.WriteLine("Received number: " + value);
        
                // Process the number as needed
            }
        }


        private async Task OnErrorAsync(Exception exception)
        {
            Console.WriteLine("An exception occurred: " + exception.Message);
            // Handle the error as per your requirements
        }

        private async Task OnCloseAsync(WebSocketCloseStatus closeStatus, string closeStatusDescription)
        {
            Console.WriteLine("WebSocket closed!");
            Console.WriteLine("Status: " + (int)closeStatus + " Reason: " + closeStatusDescription);
            // Perform any necessary cleanup or post-closure actions
        }
    }
}
