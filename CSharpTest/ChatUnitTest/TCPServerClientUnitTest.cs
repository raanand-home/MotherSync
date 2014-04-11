using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using ChatServer;
using Chat_Client;
namespace ChatUnitTest
{
    [TestClass]
    public class TCPServerClientUnitTest
    {
        ServerTcp serverTcp;
        ClientTcp clientTcp;
        ManualResetEvent onDataReceivedEvent = new ManualResetEvent(false);
        string text;
        [TestMethod]
        public void ListenTest()
        {
            //some change
            CreateServer();
            CreateClient();
            PrepareWaitForDataOnTheServer();
            clientTcp.Send("AAA");
            WaitForDataToReceived();
        }

        private void WaitForDataToReceived()
        {
            if (!onDataReceivedEvent.WaitOne(Timeout.Infinite))
            {
                Assert.Fail("Data wasn't received");
            }
        }

        private void CreateClient()
        {
            clientTcp = new ClientTcp();
            clientTcp.Start();
        }

        private void PrepareWaitForDataOnTheServer()
        {
            onDataReceivedEvent.Reset();
            serverTcp.OnMessageInQueue += new MessageInQueue(getMessageFromQueue);
        }

        private void CreateServer()
        {
            serverTcp = new ServerTcp();
            serverTcp.Start();
        }

        public void getMessageFromQueue()
        {
            byte[] Buff = serverTcp.getFromQueue();
            
            onDataReceivedEvent.Set();

            //  string temp = Buff.ToString();
            //    listBox1.Items.Add(Buff.ToString());
        }

        [TestMethod]
        public void SendToServerTest()
        {
            // Create Tcp Server
            // Listen To New Client
            
            // Create Client
            // Connect Client To Server
            // Send Message ToServer
            // Close
        }

        [TestMethod]
        public void SendToClientTest()
        {
            // Create Tcp Server
            // Listen To NewClient

            // Create Client
            // Connect Client To Server
            // Send Message from Server to the client
            // Close
        }
    }

    
}
