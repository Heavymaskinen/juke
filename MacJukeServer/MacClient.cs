using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MacJukeServer
{
    public class MacClient
    {
        public MacClient()
        {
        }

        public void Connect() {
            var client = new TcpClient(new IPEndPoint(IPAddress.Any,1000));
            var bytes = Encoding.ASCII.GetBytes("Hello");
            client.GetStream().Write(bytes,0, bytes.Length);
            client.GetStream().Close();
        }
    }
}
