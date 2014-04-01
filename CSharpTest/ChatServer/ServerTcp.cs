using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;


namespace ChatServer
{
    public delegate void MessageInQueue();
    public delegate void getConnectSocket(Socket socket);

    public class ServerTcp  /// why after write public before class OnMessageInQueue is error ???
    {
        public event MessageInQueue OnMessageInQueue;
        public event getConnectSocket OnConnect;
        public Queue<byte[]> readQueue = null;
        private Thread workerThread;
        private List<StateObject> socketConnectList;

        public ManualResetEvent allDone = new ManualResetEvent(false);
        Socket listener;
        
        public void writeToQueue(int bufSize, byte[] buffer)
        {
            readQueue.Enqueue(buffer);
            var localOnMessageInQueue = OnMessageInQueue;
            if (OnMessageInQueue != null)
            {
                OnMessageInQueue();
            }

        }

        public byte[] getFromQueue()
        {
            return readQueue.Dequeue();
        }
    

        public class StateObject
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }



        public void StartListening()
        {

            IPEndPoint localEndPoint = GetServerIpEndPoint();

            // Create a TCP/IP socket.
            listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);
                    // Wait until a connection is made before continuing.
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        private static IPEndPoint GetServerIpEndPoint()
        {
            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            return localEndPoint;
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            AskForReceive(handler, state);
        }

        private void AskForReceive(Socket handler, StateObject state)
        {
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket workSocket = state.workSocket;
            RaiseOnConnect(workSocket);

            // Read data from the client socket. 
            int bytesRead = workSocket.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                writeToQueue(bytesRead, state.buffer);

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.
                    Send(workSocket, content);
                }
                AskForReceive(state.workSocket, state);                 
  
            }
        }

        private void RaiseOnConnect(Socket workSocket)
        {
            var localOnConnect = OnConnect;
            if (localOnConnect != null)
            {
                localOnConnect(workSocket);
            }
        }

        public void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
             var waithadler = handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
             waithadler.AsyncWaitHandle.WaitOne();
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                // close socket
          //      handler.Shutdown(SocketShutdown.Both);
          //      handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        bool IsRunning = true;
//        private bool _shouldStop;
        public void Start()
        {
            IsRunning = true;
            workerThread = new Thread(StartListening);

            workerThread.Start();
            this.readQueue = new Queue<byte[]>();
        }

        public void Stop()
        {
            //handler.Shutdown(SocketShutdown.Both);
            //handler.Close();
            //workerThread.H
        }
    }
}
