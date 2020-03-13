using System;
using System.Net;

namespace SCLClientTest
{
    class Program
    {
        static void Main()
        {
            SCLCore.SCLClient client = new SCLCore.SCLClient(IPAddress.Parse("127.0.0.1"), 4000);
            client.StartSCLClient();
        }
    }
}
