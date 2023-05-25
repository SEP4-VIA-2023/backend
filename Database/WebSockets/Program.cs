using EFCDataAccess;
using EFCDataAccess.DAOs;
using WebSockets.Gateway;


string st =  @"
{
    ""cmd"": ""rx"",
    ""seqno"": 2746,
    ""EUI"": ""0004A30B00E7E212"",
    ""ts"": 1682681047297,
    ""fcnt"": 8,
    ""port"": 2,
    ""freq"": 867100000,
    ""rssi"": -116,
    ""snn"": -13,
    ""toa"": 0,
    ""dr"": ""SF12 BW125 4/5"",
    ""ack"": false,
    ""bat"": 255,
    ""offline"": false,
    ""data"": ""039201a1010b01""
}";

DataContext dataContext = new DataContext();

MeasurementDAO msdao = new MeasurementDAO(dataContext);

WebsocketClient server = new WebsocketClient(msdao);

await server.ProcessReceivedDataAsync(st);


