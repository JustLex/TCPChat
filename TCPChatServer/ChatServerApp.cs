using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Threading;

namespace TCPChatServer
{
    class ChatServerApp
    {
        static Server server = new Server();
        enum commands {exit, start};
        delegate void command();

        static void Main(string[] args)
        {
            Console.WriteLine("TCPChat server v0\nType \"help\" for list of commands");
            string command = "";
            while (command != "exit") {
                Console.WriteLine("Waiting for command");
                command = Console.ReadLine();
                switch (command) {
                    case ("start"): { executeCommand( new command(startServer) ) ; break; }
                    case ("exit"): { executeCommand(new command(exitServer)); break; }
                    case ("status"): { executeCommand(new command(printStatus)); break; }
                    case ("pause"): { break; }
                    case ("restart"): { break;}
                    case ("help"): { executeCommand(new command(showHelp)); break; }
                    default: { Console.WriteLine("Unknown command"); break; }
                }
            }
        }

        static private void executeCommand(Delegate command) {
            Console.WriteLine("--------------------------------------------");
            command.DynamicInvoke();
            Console.WriteLine("--------------------------------------------");
        }

        static private void showHelp() { 
            Console.WriteLine("List of commands\n"+
                "start\n"+
                "exit\n"+
                "help\n"+
                "status");
        }

        static private void startServer() {
            if (server.isServerRunning)
            {
                Console.WriteLine("Server is already running");
            }
            else {
                Console.WriteLine("Starting server...");
                server.startServer();
                Console.WriteLine(server.isServerRunning ? "Server started" : "Server failed to start");
            }
        }

        static private void exitServer() {
            Console.WriteLine("Server is shutting down...");
            server.stopServer();
            Console.WriteLine("Goodbye");
        }

        static void printStatus() {
            if (server.isServerRunning)
            {
                Console.WriteLine("Server online");
            }
            else {
                Console.WriteLine("Server offline");
            }
        }
    }
}
