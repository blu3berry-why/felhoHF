namespace HelloWebSocketService
{
    using System.Net.WebSockets;
    using System.Text.Json;
    using WebSocket_VSQUVG.Cinema;
    using WebSocket_VSQUVG.Types;
    using WebSocket_VSQUVG.Types.Req;

    namespace HelloWebSocketService
    {
        public class HelloEndpoint
        {
            public Cinema cinema;
            public List<WebSocket> Sockets { get; set; }
            public List<WebSocket> Reserved { get; set; }
            public List<WebSocket> Locked { get; set; }

            public async Task Open(WebSocket socket)
            {
                Sockets.Add(socket);
                Console.WriteLine("WebSocket opened.");
            }
            public async Task Close(WebSocket socket)
            {
                Sockets.Remove(socket);
                Console.WriteLine("WebSocket closed.");
            }
            public async Task Error(WebSocket socket, Exception ex)
            {
                Console.WriteLine("WebSocket error: " + ex.Message);
            }
            public async Task<string> Message(WebSocket socket, string message)
            {
                BaseType obj = JsonSerializer.Deserialize<BaseType>(message);
                switch (obj.Type) {
                    case "initRoom":
                        var init = JsonSerializer.Deserialize<MovieInit>(message);
                        cinema.Init(init.Rows, init.Columns);
                        break;
                    case "getRoomSize":
                        
                        break;
                    case "updateSeats":
                        break;
                    case "lockSeat":
                        var obj2 = JsonSerializer.Deserialize<SeatLock>(message);
                        break;
                    case "unlockSeat":
                        break;
                    case "reserveSeat":
                        break;
                    default:
                        break;

                }

                Console.WriteLine($"WebSocket message: {message}");
                return $"Hello: {message}";
            }
        }
    }
}
