using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSockets.Gateway
{
    public class WebsocketClient
    {
        private ClientWebSocket _websocket;
        private CancellationTokenSource _cancellationTokenSource;

        public WebsocketClient()
        {
            _websocket = new ClientWebSocket();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task ConnectAsync(string url,StringContent info)
        {
            try
            {
                await _websocket.ConnectAsync(new Uri(url), CancellationToken.None);
                Console.WriteLine("Websocket connection has been opened.");

                // Start a new thread to send data periodically
                var thread = new Thread(async () => await SendDataAsync(info));
                thread.Start();

                await ReceiveLoopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            finally
            {
                if (_websocket.State != WebSocketState.Closed)
                    await _websocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by client", CancellationToken.None);
                _websocket.Dispose();
            }
        }
        
            private async Task ReceiveLoopAsync()
            {
                var buffer = new byte[1024];
                try
                {
                    while (_websocket.State == WebSocketState.Open)
                    {
                        WebSocketReceiveResult result = await _websocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            string data = Encoding.UTF8.GetString(buffer, 0, result.Count);
                            Console.WriteLine("Received message: " + data);
                        }
                    }
                }
                catch (WebSocketException ex)
                {
                    // Handle WebSocket exception here
                    Console.WriteLine("WebSocket exception occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception occurred while receiving data: " + ex.Message);
                }
                finally
                {
                    if (_websocket.State != WebSocketState.Closed)
                    {
                        await CloseConnectionAsync();
                    }
                }
            }

        

        private async Task SendDataAsync(StringContent message)
        {
            try
            {
                string jsonString = await message.ReadAsStringAsync();

                // Deserialize the JSON string into the desired object
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // Access the properties of the deserialized object as needed
                // For example: deserializedObject.PropertyName

                byte[] buffer = Encoding.UTF8.GetBytes(jsonString);
                await _websocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

                Console.WriteLine("Message sent: " + jsonContent);
                await CloseConnectionAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while sending data: " + ex.Message);
            }
        }
        
        private async Task CloseConnectionAsync()
        {
            try
            {
                if (_websocket.State == WebSocketState.Open || _websocket.State == WebSocketState.CloseReceived)
                {
                    await _websocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by client", CancellationToken.None);
                    Console.WriteLine("Websocket connection has been closed.");
                }
            }
            catch (WebSocketException ex)
            {
                // Handle WebSocket exception here
                Console.WriteLine("WebSocket exception occurred while closing the connection: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while closing the connection: " + ex.Message);
            }
            finally
            {
                _websocket.Dispose();
            }
        }




    }
}



