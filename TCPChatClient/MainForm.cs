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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;

namespace Chat_Client
{
    public partial class MainForm : Form
    {

        static private Client client = new Client();
        static public Parameters prop;
        /// <summary>
        /// Список потоков.
        /// </summary>
        static private List<Thread> threads = new List<Thread>();
        /// <summary>
        /// Делегат для доступа к textBox контроллам
        /// </summary>
        /// <param name="text"></param>
        delegate void Del(string text);

        public MainForm()
        {
            InitializeComponent();            
            prop = Parameters.deserializeParams();
            tryConnection();  
        }

        /// <summary>
        /// Установка попытки соединения.
        /// </summary>
        void tryConnection() {
            statusConnection.Text = "Connecting...";
            Thread th = new Thread(delegate() {
                client.initiateClient(prop.server, prop.port);
                statusConnection.Text = client.isClientRunning ? "Connected: Local version" : "Failed to connect";
                Receiver();
            });
            th.IsBackground = true;
            th.Start();
        }

         void Receiver()
        {
            Thread th = new Thread(delegate()
            {
                while (client.isClientRunning)
                {
                    string data = client.getMessage();
                    outText.Invoke(new Del((s) => outText.Text += s), data);
                    outText.Invoke(new Del((s) => outText.Text += s), Environment.NewLine);
                }
            });
            th.Start();
            th.IsBackground = true;
            threads.Add(th);
        }

        private void sendButtonClick(object sender, EventArgs e)
        {
            compileMessage();
        }

        private void messageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                compileMessage();
            }
        }
        /// <summary>
        /// Подготовка и отправка сообщения.
        /// </summary>
        private void compileMessage() {
            if (client.isClientRunning)
            {
                client.sendMessage(messageBox.Text, prop.nickname);
                messageBox.Clear();
            }
        } 

        private void menuOptions_Click(object sender, EventArgs e)
        {
            string oldIP = prop.server;
            OptionForm opForm = new OptionForm(prop);
            if (opForm.ShowDialog() == DialogResult.OK && prop.server != oldIP) {
                client.closeConnection();
                tryConnection();
            }
            if (!client.isClientRunning)
            {
                tryConnection();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
