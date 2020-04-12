using System.Linq;
using System.Net;

namespace SCLSync
{
    public static class Server
    {
        private static SCLServer server;
        /// <summary>
        /// Start the server for server side protection with IP and Port specified.
        /// </summary>
        public static void Start(string IP, int Port)
        {
            server = new SCLServer(IPAddress.Parse(IP), Port);
            server.StartSCLServer();
        }

        /// <summary>
        /// Check if ip passed in argument is valid and can login.
        /// <returns>
        /// Return true if valid false else
        /// </returns>
        /// </summary>
        public static bool IsAuthorizedIP(string IP)
        {
            return server.IPAlloweds.Where(x => x.ToString() == IP).Count() > 0;
        }

        /// <summary>
        /// Reset the IP validation of specified IP.
        /// <returns>
        /// Reset the validation for the ip passed of argument
        /// </returns>
        /// </summary>
        public static void ResetValidation(string IP)
        {
            IPAddress ipAddr = server.IPAlloweds.Where(x => x.ToString() == IP).FirstOrDefault();
            if (ipAddr != null)
            {
                server.IPAlloweds.Remove(ipAddr);
            }
        }
    }
}
