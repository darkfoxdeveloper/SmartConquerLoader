using System;
using System.Linq;
using System.Net;

namespace SCLServerSideProtection
{
    public static class Core
    {
        private static SCLCore.SCLServer server;
        /// <summary>
        /// Start the server for server side protection with IP and Port specified.
        /// </summary>
        public static void Start(string IP, int Port)
        {
            server = new SCLCore.SCLServer(IPAddress.Parse(IP), Port);
            server.StartSCLServer();
        }

        /// <summary>
        /// Check if ip passed in argument is valid and can login.
        /// <returns>
        /// Return true if valid false else
        /// </returns>
        /// </summary>
        public static bool CanLogin(string IP)
        {
            return server.IPAlloweds.Where(x => x.ToString() == IP).Count() > 0;
        }
    }
}
