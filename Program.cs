using Fleck;



var server = new WebSocketServer("ws://0.0.0.0:3000");

var connections = new List<IWebSocketConnection>();
server.Start(ws =>
{
  ws.OnOpen = () =>
  {
    connections.Add(ws);
  };
  ws.OnMessage = message =>
  {
    foreach (var cn in connections)
    {
      if (cn != ws)
      {

        cn.Send(message);
      }

    };
  };
});
WebApplication.CreateBuilder(args).Build().Run();
