using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Chat.Lib.Test
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        public void BasicConnect()
        {
            TcpServerConnection connection = new TcpServerConnection();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 13532);
            connection.Connect(endPoint);
        }
    }
}
