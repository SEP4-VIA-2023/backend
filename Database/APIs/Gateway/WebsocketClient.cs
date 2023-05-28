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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;


namespace WebSockets.Gateway
{
    public class WebsocketClient
    {
        private ClientWebSocket _websocket;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly IMeasurementDAO _measurementDao;
        private MeasurementConverter mscontroller;
        private DataContext _dataContext;
        private readonly IPresetDAO _presetDao;

        public WebsocketClient()
        {
            _websocket = new ClientWebSocket();
            _cancellationTokenSource = new CancellationTokenSource();

            mscontroller = new MeasurementConverter();
            _dataContext = new DataContext();
            _measurementDao = new MeasurementDAO(_dataContext);
            _presetDao = new PresetDAO(_dataContext);
        }

        public async Task ConnectAsync(string url)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await _websocket.ConnectAsync(new Uri(url), CancellationToken.None);
                Console.WriteLine("Websocket connection has been opened.");

                // Start the receive task
                var receiveTask = ReceiveLoopAsync();

                // Start sending data periodically
                var sendTask = SendDataPeriodicallyAsync();

                // Wait for either the receive or send task to complete
                await Task.WhenAny(receiveTask, sendTask);

                // Cancel the remaining task
                _cancellationTokenSource.Cancel();

                // Wait for both tasks to complete
                await Task.WhenAll(receiveTask, sendTask);
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
                    Console.WriteLine("Websocket closed");
                }

                _websocket.Dispose();
            }
        }

        public async Task SendDataPeriodicallyAsync()
        {
            try
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    Preset preset = await _presetDao.GetActivePresetAsync(1);
                    await SendDataAsync(preset);
                    await Task.Delay(TimeSpan.FromMinutes(4), _cancellationTokenSource.Token);
                }
            }
            catch (TaskCanceledException)
            {
                // The task was canceled, no further action needed
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred while sending data: " + ex.Message);
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
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner exception: " + ex.InnerException.Message);
                }
            }
        }


        public async Task ProcessReceivedDataAsync(string data)
        {
            var measurement = JObject.Parse(data);

            if (measurement.TryGetValue("cmd", out var cmdValue) && cmdValue.Value<string>() == "rx")
            {
                if (measurement["data"] == null)
                {
                    throw new InvalidDataException();
                }

                var stringD = measurement["data"].Value<string>();

                // Create the DateTime object with DateTimeKind.Local


                var measurements = new Measurement(
                    0,
                    DateTime.Now.AddHours(2),
                    mscontroller.GetHumidity(stringD),
                    mscontroller.GetCO2(stringD),
                    mscontroller.GetTemperature(stringD),
                    mscontroller.GetServo(stringD),
                    1);

                try
                {
                    await _measurementDao.CreateAsync(measurements);
                    Console.WriteLine(measurements.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }


        public async Task SendDataAsync(Preset preset)
        {
            Console.WriteLine(preset.ToString());

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
                string payloadData =
                    $"{minCO2:X4}{maxCO2:X4}{minHum:X4}{maxHum:X4}{minTemp:X4}{maxTemp:X4}{servoStatus:X2}";

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
                await _websocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(payloadJson)),
                    WebSocketMessageType.Text, true, CancellationToken.None);

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