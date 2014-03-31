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

        public ServerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serverTcp = new ServerTcp();
            Thread workerThread = new Thread(serverTcp.Start);
            serverTcp.OnMessageInQueue += new MessageInQueue(getMessageFromQueue);

            workerThread.Start(sender);
            listBox1.Items.Add((string)"zzzzz");
            listBox1.Items.Add("aaaaa");
//            StartListening();
            
        }

        public void getMessageFromQueue()
        {
            TcpBuffer tcpBuff = serverTcp.getFromQueue();
            listBox1.Items.Add(tcpBuff.buf);
        }
        private void button2_Click(object sender, EventArgs e)
        {
//            listener.Close();
            serverTcp.Stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
