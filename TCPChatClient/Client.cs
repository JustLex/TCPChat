using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    class Client
    {
        public Socket clientSocket;
        public bool isClientRunning;
        private int port = 6667;
        private IPAddress clientIP;

        public void initiateClient() {
            try
            {
                isClientRunning = true;
                clientIP = IPAddress.Parse("127.0.0.1");
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(clientIP, port);
            }
            catch { }
        }

        public void sendMessage(string msg){
            try
            {
                byte[] bytes = new byte[1024];
                bytes = Encoding.UTF8.GetBytes(msg);
                clientSocket.Send(bytes);
            }
            catch { }
        }

        public string getMessage() {
            try
            {
                byte[] bytes = new byte[1024];
                clientSocket.Receive(bytes);
                if (bytes.Length != 0)
                {
                    string data = Encoding.UTF8.GetString(bytes);
                    return data;
                }
            }
            catch { }
            return null;
        }
    }
}
