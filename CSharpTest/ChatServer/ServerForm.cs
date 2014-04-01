using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        ServerTcp serverTcp;
        Socket connectSocket = null;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serverTcp = new ServerTcp();
            serverTcp.Start();
            serverTcp.OnMessageInQueue += new MessageInQueue(getMessageFromQueue);
            serverTcp.OnConnect += new getConnectSocket(getConnectSocket);
            /*
            Thread workerThread = new Thread(serverTcp.Start);

            workerThread.Start();
             * */
            listBox1.Items.Add((string)"zzzzz");
            listBox1.Items.Add("aaaaa");
//            StartListening();
            
        }

        public void getMessageFromQueue()
        {
            byte[] Buff = serverTcp.getFromQueue();
            Console.WriteLine(Buff.ToString());

          //  string temp = Buff.ToString();
        //    listBox1.Items.Add(Buff.ToString());
        }
        public void getConnectSocket(Socket socket)
        {
            connectSocket = socket;
            //  string temp = Buff.ToString();
            //    listBox1.Items.Add(Buff.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
//            listener.Close();
            serverTcp.Stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SendMessagebutton_Click(object sender, EventArgs e)
        {
            if (connectSocket != null)
            {
                serverTcp.Send(connectSocket, "send message <EOF>");
            }
        }
    }
}
