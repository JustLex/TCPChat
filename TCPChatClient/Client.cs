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
        public bool isClientRunning = false;
        private IPAddress clientIP;
        private int port;

        public void initiateClient(string ip, int port) {
            try
            {
                clientIP = IPAddress.Parse(ip);
                this.port = port;
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(clientIP, port);
                isClientRunning = true;
            }
            catch {
                isClientRunning = false;
            }
        }

        public void sendMessage(string msg, string name){
            try
            {
                byte[] bytes = new byte[1024];
                msg = name + ": " + msg;
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

        public void closeConnection() {
            isClientRunning = false;
            clientSocket.Close();
        }
    }
}
