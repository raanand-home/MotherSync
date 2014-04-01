using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using ChatServer;
namespace ChatUnitTest
{
    [TestClass]
    public class TCPServerClientUnitTest
    {
        public ServerTcp serverTcp;
        [TestMethod]
        public void ListenTest()
        {
            // Create Tcp Server
//            serverTcp = new ServerTcp();
//            Thread workerThread = new Thread(serverTcp.Start);
            //serverTcp.OnMessageInQueue += new MessageInQueue(getMessageFromQueue);
   //         serverTcp.AddEventHAndle(new MessageInQueue(getMessageFromQueue));

//            workerThread.Start();
            // Listen To New Client
            // Close
        }

        public void getMessageFromQueue()
        {
            byte[] Buff = serverTcp.getFromQueue();
            Console.WriteLine(Buff.ToString());

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
        public void SendToServerTest()
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
