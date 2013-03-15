using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPChatServer
{
    class Server
    {
        const string SHUTDOWN_CMD = "";
        public bool isServerRunning;
        private ArrayList clients;
        private Socket serverSocket;
        private IPEndPoint serverPoint;
        private static int port = 6667;
        private static List<Thread> clientThreads = new List<Thread>();

        public void startServer()
        {
            clients = new ArrayList();
            isServerRunning = true;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverPoint = new IPEndPoint(IPAddress.Any, port);

            serverSocket.Bind(serverPoint);
            serverSocket.Listen(20);
            startSocketThreads();
        }

       private void startSocketThreads()
       {
        Thread processConnestions = new Thread(new ThreadStart(processSocket));
        processConnestions.IsBackground = true;
        processConnestions.Start();
       }

       private void processSocket()
       {
       while (isServerRunning)
       {
           Socket clientSocket = serverSocket.Accept();
           if (!clients.Contains(clientSocket))
           {
               clients.Add(clientSocket);
               Thread clientThread = new Thread(delegate() { messageManager(clientSocket); });
               clientThreads.Add(clientThread);
               clientThread.IsBackground = true;
               clientThread.Start();
           }
           }
        }

        private void messageManager(Socket client)
        {
            try
            {
                while (isServerRunning)
                {
                    byte[] buffer = new byte[1024];
                    client.Receive(buffer);
                    if (buffer.Length != 0)
                    {
                        broadcastMsg(buffer);
                    }
                }
            }
            catch
            {
               clients.Remove(client);
               clientThreads.Remove(Thread.CurrentThread);
           }
       }

        private void broadcastMsg(byte[] msg) {
            foreach (Socket reciever in clients)
            {
                sendMessage(reciever, msg);
            }
        }

       void sendMessage(Socket reciever, byte[] message)
       {
           reciever.Send(message);
       }

       public void stopServer() {
           isServerRunning = false;
       }
    }
}
