using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MacJukeServer
{
    public class MacServer
    {
        private Thread listenThread;
        private TcpListener listener;
        public string receivedMessage;

        public MacServer()
        {
            listener = new TcpListener(new System.Net.IPEndPoint(IPAddress.Any, 1000));
            listenThread = new Thread(new ParameterizedThreadStart(ListenProcess));
                listener.Start();

        }

        private void ListenProcess(object clientObj) {
            TcpClient tcpClient = (TcpClient)clientObj;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }
                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                receivedMessage = encoder.GetString(message, 0, bytesRead);
            }
        }
    }
}
