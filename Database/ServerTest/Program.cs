using System;

using ServerTest;

var server = new WebSocketServer("http://localhost:8080/");
await server.Start();