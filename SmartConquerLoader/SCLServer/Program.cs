using System.Net;

namespace SCLServer
{
    class Program
    {
        static void Main()
        {
            SCLCore.SCLServer server = new SCLCore.SCLServer(IPAddress.Parse("127.0.0.1"), 4000);
            server.StartSCLServer();
        }
    }
}
