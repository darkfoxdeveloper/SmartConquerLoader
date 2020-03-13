using System;
using System.Net;
using System.Text;
using System.Threading;
using TcpClient = NetCoreServer.TcpClient;

namespace SCLCore
{
    public class SCLClient : TcpClient
    {
        private IPAddress Address = null;
        private int Port = 0;
        public SCLClient(IPAddress address, int port) : base(address, port)
        {
            Address = address;
            Port = port;
        }
        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine(message);
        }

        public void DisconnectAndStop()
        {
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        public void StartSCLClient()
        {
            Console.WriteLine($"[SCLClient] address: {Address}");
            Console.WriteLine($"[SCLClient] port: {Port}");
            Console.WriteLine();

            // Create a new TCP chat client

            // Connect the client
            Console.Write("[SCLClient] Client connecting...");
            if (this.Connect())
            {
                AuthIP();
                Console.WriteLine("[SCLClient] Done!");
                Console.WriteLine("[SCLClient] Press Enter to stop the client or '!' to reconnect the client...");

                // Perform text input
                for (; ; )
                {
                    string line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;

                    // Disconnect the client
                    if (line == "!")
                    {
                        SafeDisconnect();
                        continue;
                    }

                    // Send the entered text to the chat server
                    this.SendAsync(line);
                }

                // Disconnect the client
                //Console.Write("[SCLClient] Client disconnecting...");
                //this.DisconnectAndStop();
                //Console.WriteLine("[SCLClient] Done!");
            }
        }

        private void AuthIP()
        {
            IPEndPoint localIpEndPoint = this.Socket.LocalEndPoint as IPEndPoint;
            this.SendAsync("/authip " + localIpEndPoint.Address);
        }

        public void SafeDisconnect()
        {
            IPEndPoint localIpEndPoint = Socket.LocalEndPoint as IPEndPoint;
            this.SendAsync("/removeip " + localIpEndPoint.Address);
            Console.Write("[SCLClient] Client disconnecting...");
            this.DisconnectAsync();
            Console.WriteLine("[SCLClient] Done!");
        }
    }
}
