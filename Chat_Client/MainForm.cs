using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;

namespace Chat_Client
{
    public partial class MainForm : Form
    {
        static public propeties prop;
        // Статус клиента
        static private bool client_running;
        // Сокет клиента
        static  private Socket client;
        // Адрес сервера
        static private IPAddress ip = IPAddress.Parse("127.0.0.1");
        // Порт, по которому будем присоединяться
        static private int port = 1991;
        // Список потоков
        static private List<Thread> threads = new List<Thread>();

        void Connect()
        {
            try
            {
                client_running = true;
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ip, port);
                Receiver();
            }
            catch { }
        }

         void Receiver()
        {
            Thread th = new Thread(delegate()
            {
                while (client_running)
                {
                    try
                    {
                        byte[] bytes = new byte[1024];
                        // Принимает данные от сервера в формате "X|Y"
                        client.Receive(bytes);
                        if (bytes.Length != 0)
                        {
                            string data = Encoding.UTF8.GetString(bytes);
                            outText.Text = outText.Text + data + '\n';
                        }
                        
                    }
                    catch { }
                }
            });
            th.Start();
            threads.Add(th);
        }

        static void Sender(string msg)
        {
            try
            {
                byte[] bytes = new byte[1024];
                bytes = Encoding.UTF8.GetBytes(msg);
                client.Send(bytes);
            }
            catch { }
        }



        public MainForm()
        {
            InitializeComponent();
            
            statusConnection.Text = "Connected: Demo Version";

            prop = new propeties();
            if (File.Exists("propeties.cfg") == false)
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(propeties));
                System.IO.StreamWriter file = new System.IO.StreamWriter("propeties.cfg");
                prop.server = "127.0.0.1";
                prop.nickname = "Player";
                writer.Serialize(file, prop);
                file.Close();
            }
            else
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(propeties));
                System.IO.StreamReader file = new System.IO.StreamReader("propeties.cfg");
                prop = (propeties)reader.Deserialize(file);
                file.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

                string message;
                message = messageBox.Text;
                SendMessage(message);
                outText.Text = outText.Text + message + '\n';
                messageBox.Text = "";
                

        }

        static private void SendMessage(string message)
        {
            Sender(message);
        }

        static private void Listner()
        {
            
        }

        private void menuOptions_Click(object sender, EventArgs e)
        {
            OptionForm opForm = new OptionForm();
            opForm.ShowDialog();
        }

        private void messageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string message;
                message = messageBox.Text;
                SendMessage(message);
                outText.Text = outText.Text + message + '\n';
                messageBox.Text = "";
                
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
