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
using EFCDataAccess.DAOs;
using Newtonsoft.Json.Serialization;



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
            _dataContext = new DataContext();
        }
        
        public async Task ConnectAsync(string url)
        {
            try
            {
                await _websocket.ConnectAsync(new Uri(url), CancellationToken.None);
                Console.WriteLine("Websocket connection has been opened.");


                // Start the receive task
                await  ReceiveLoopAsync();
                

                // Start a new thread to send data periodically
                /*var thread = new Thread(async () => await SendDataAsync(minCO2,maxCO2, minHumidity, maxHumidity, minTemp, maxTemp, rotationPercentage));
                thread.Start();
                */


                /*// Start the send task
                var sendTask = SendDataAsync();*/

                /*// Wait for both tasks to complete
                await Task.WhenAll(receiveTask, sendTask);*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: " + ex.Message);
            }
            finally
            {
                if (_websocket.State != WebSocketState.Closed)
                {
                    await CloseConnectionAsync();
                    Console.WriteLine("websocket closed");
                }
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
                    WebSocketReceiveResult result = await _websocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
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
                Console.WriteLine("WebSocket exception occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while receiving data: " + ex.Message);
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







       
        
        public async Task SendDataAsync(PresetDTO preset)
        {     Console.WriteLine(preset);
            if (_websocket.State != WebSocketState.Open)
            {
                Console.WriteLine("The WebSocket is not connected or is not in the Open state. Cannot send data.");
                return;
            }
            try
            {
                /*IPresetDAO presetDao = new PresetDAO(_dataContext);
                Preset preset = await presetDao.GetByIdAsync(3);*/

                ushort minCO2 = (ushort)preset.MinCo2;
                ushort maxCO2 = (ushort)preset.MaxCo2;
                ushort minHum = (ushort)preset.MinHumidity;
                ushort maxHum = (ushort)preset.MaxHumidity;
                short minTemp = (short)preset.MinTemperature;
                short maxTemp = (short)preset.MaxTemperature;
                byte servoStatus = (byte)preset.Servo;

                // Convert the preset values to hexadecimal strings
                string payloadData = $"{minCO2:X4}{maxCO2:X4}{minHum:X4}{maxHum:X4}{minTemp:X4}{maxTemp:X4}{servoStatus:X2}";
                
// Create the JSON payload
                var payload = new
                {
                    cmd = "tx",
                    EUI = "0004A30B00251192",
                    port = 1,
                    data = payloadData
                };


// Serialize the JSON payload to a string
                string payloadJson = JsonConvert.SerializeObject(payload);


// Send the JSON payload
                await _websocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(payloadJson)), WebSocketMessageType.Text, true, CancellationToken.None);

                Console.WriteLine("Data sent successfully.");
                Console.WriteLine(payloadData);
                
                int payloadByteCount = Encoding.UTF8.GetByteCount(payloadJson);
                Console.WriteLine("Payload byte count: " + payloadByteCount);
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while sending data: " + ex.Message);
            }
        }


        



        public async Task CloseConnectionAsync()
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