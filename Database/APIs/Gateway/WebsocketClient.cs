using System;
using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;
using EFCDataAccess;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using APIs.Controllers;


namespace WebSockets.Gateway
{
    public class WebsocketClient
    {
        private ClientWebSocket _websocket;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly IMeasurementDAO _measurementDao;
        private MeasurementConverter mscontroller;

        public WebsocketClient()
        {
            _websocket = new ClientWebSocket();
            _cancellationTokenSource = new CancellationTokenSource();
            // _measurementDao = measurementDao;
            mscontroller = new MeasurementConverter();
        }

        public async Task ConnectAsync(string url, StringContent info)
        {
            try
            {
                await _websocket.ConnectAsync(new Uri(url), CancellationToken.None);
                Console.WriteLine("Websocket connection has been opened.");

                // Start a new thread to send data periodically
                /*var thread = new Thread(async () => await SendDataAsync(minCO2,maxCO2, minHumidity, maxHumidity, minTemp, maxTemp, rotationPercentage));
                thread.Start();
                */

                await ReceiveLoopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            finally
            {
                if (_websocket.State != WebSocketState.Closed)
                    await _websocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by client",
                        CancellationToken.None);
                _websocket.Dispose();
            }
        }

        private async Task ReceiveLoopAsync()
        {
            var buffer = new byte[4096];
            try
            {
                while (_websocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result =
                        await _websocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string data = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        Console.WriteLine("Received message: " + data);

                        // Process the received JSON data
                        await ProcessReceivedDataAsync(data);
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

        public async Task ProcessReceivedDataAsync(string data)
        {
            var measurement = JObject.Parse(data);
            Console.WriteLine(measurement + " " + data);

            if (measurement.TryGetValue("cmd", out var cmdValue) && cmdValue.Value<string>() == "rx")
            {
                Console.WriteLine("WebSocketClient: Received data");

                
                var eui = measurement["EUI"].Value<string>();
                var timestamp = measurement["ts"].Value<long>();
                var fcnt = measurement["fcnt"].Value<int>();
                var port = measurement["port"].Value<int>();
                var ack = measurement["ack"].Value<bool>();
                var hexData = measurement["data"].Value<string>();

                Console.WriteLine("EUI: " + eui);
                Console.WriteLine("Timestamp: " + timestamp);
                Console.WriteLine("FCnt: " + fcnt);
                Console.WriteLine("Port: " + port);
                Console.WriteLine("ACK: " + ack);
                Console.WriteLine("Hex Data: " + hexData);
        
                if (measurement["data"] == null)
                {
                    throw new InvalidDataException();
                }

                var stringD = measurement["data"].Value<string>();

                Console.WriteLine(stringD);
                var measurements = new Measurement(
                    1,
                    0,
                    DateTime.Now,
                    mscontroller.GetHumidity(stringD),
                    mscontroller.GetCO2(stringD),
                    mscontroller.GetTemperature(stringD),
                    mscontroller.GetServo(stringD),
                    1)
                ;

                Console.WriteLine(measurements.ToString());
            }
        }







        
        

       /*
       public async Task SendDataAsync()

        {

            try
            {
                var configurationService = new ConfigService();
                var configuration = configurationService.CreateConfiguration(minCO2, maxCO2, minHumidity, maxHumidity, minTemp, maxTemp, rotationPercentage);

                string jsonString = JsonConvert.SerializeObject(configuration);
                byte[] buffer = Encoding.UTF8.GetBytes(jsonString);


                await _websocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

                Console.WriteLine("Message sent: " + jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while sending data: " + ex.Message);
            }
        }

        */
        

        private async Task CloseConnectionAsync()
        {
            try
            {
                if (_websocket.State == WebSocketState.Open || _websocket.State == WebSocketState.CloseReceived)
                {
                    await _websocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by client",
                        CancellationToken.None);
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