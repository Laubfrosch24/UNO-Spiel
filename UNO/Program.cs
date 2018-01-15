using Fleck;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class Program
    {
        const int HttpPort = 1337;
        const int WebSocketPort = 666;

        static void Main(string[] args)
        {
            new SimpleHTTPServer("Web", HttpPort);
            WebSocketServer wss = new WebSocketServer($"ws://0.0.0.0:{WebSocketPort}");
            wss.Start(socket => {
                socket.OnOpen = () => socket.Send("Halloasdasdasd");
            });

#if DEBUG
            Process.Start($"http://localhost:{HttpPort}");
#endif
        }
    }
}
