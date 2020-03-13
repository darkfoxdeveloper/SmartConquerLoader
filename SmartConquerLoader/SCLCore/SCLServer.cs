using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SCLCore
{
    class SCLSession : TcpSession
    {
        private SCLServer SCLServer;
        public SCLSession(SCLServer server) : base(server) {
            SCLServer = server;
        }

        protected override void OnConnected()
        {
            Console.WriteLine($"[SCLSession] Id {Id} connected!");

            // Send invite message
            string message = "[SCLSession] Please send a message or '!' to disconnect the client!";
            SendAsync(message);
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"[SCLSession] Id {Id} disconnected!");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine("[SCLServer] Incoming message from client: " + message);

            // Multicast message to all connected sessions
            // Server.Multicast(message);

            if (message.StartsWith("/"))
            {
                string[] commandArgs = message.Split("/")[1].Split(" ");
                switch(commandArgs[0])
                {
                    case "authip":
                        {
                            if (SCLServer.IPAlloweds.Where(x => x.ToString() == commandArgs[1]).Count() <= 0)
                            {
                                IPAddress ip = IPAddress.Parse(commandArgs[1]);
                                SCLServer.IPAlloweds.Add(ip);
                                Console.WriteLine("[SCLServer] authip command from client.");
                            } else
                            {
                                Console.WriteLine("[SCLServer] error on add ip.");
                            }
                            break;
                        }
                    case "removeip":
                        {
                            IPAddress ip = IPAddress.Parse(commandArgs[1]);
                            SCLServer.IPAlloweds.RemoveAll(x => x.ToString() == ip.ToString());
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("[SCLServer] Invalid command from client.");
                            Console.WriteLine("------------------------");
                            break;
                        }
                }
            }

            // If the buffer starts with '!' the disconnect the current session
            if (message == "!")
                Disconnect();
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"[SCLSession] caught an error with code {error}");
        }
    }

    public class SCLServer : TcpServer
    {
        private IPAddress Address = null;
        private int Port = 0;
        public List<IPAddress> IPAlloweds;
        public SCLServer(IPAddress address, int port) : base(address, port) {
            Address = address;
            Port = port;
            IPAlloweds = new List<IPAddress>();
        }

        protected override TcpSession CreateSession() { return new SCLSession(this); }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"[SCLServer] caught an error with code {error}");
        }
        public void StartSCLServer()
        {
            Console.WriteLine($"[SCLServer] address: {Address}");
            Console.WriteLine($"[SCLServer] port: {Port}");

            Console.WriteLine();

            // Start the server
            this.Start();
            Console.WriteLine("[SCLServer] Done! Waiting connections...");
            Console.WriteLine("[SCLServer] Press Enter to stop the server or '!' to restart the server...");

            // Perform text input
            for (; ; )
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;

                // Restart the server
                if (line == "!")
                {
                    Console.Write("[SCLServer] Server restarting...");
                    this.Restart();
                    Console.WriteLine("[SCLServer] Done!");
                    continue;
                }

                if (line.StartsWith("/"))
                {
                    string[] commandArgs = line.Split("/")[1].Split(" ");
                    switch (commandArgs[0])
                    {
                        case "allowedips":
                            {
                                Console.WriteLine();
                                Console.WriteLine("------ SCLServer | IP Alloweds ------");
                                foreach (IPAddress addr in IPAlloweds)
                                {
                                    Console.WriteLine(addr);
                                }
                                Console.WriteLine("-------------------------------------");
                                break;
                            }
                        case "bc":
                            {
                                // Multicast admin message to all sessions
                                string messageFixed = string.Join(" ", commandArgs, 1, commandArgs.Length-1);
                                this.Multicast(messageFixed);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("------------------------");
                                Console.WriteLine("[SCLServer] Invalid command from server.");
                                Console.WriteLine("------------------------");
                                break;
                            }
                    }
                }
            }

            // Stop the server
            Console.Write("[SCLServer] Server stopping...");
            this.Stop();
            Console.WriteLine("[SCLServer] Done!");
        }
    }
}
