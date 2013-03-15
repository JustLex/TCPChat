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

        static private Client client = new Client();
        static public Propeties prop;
        // Список потоков
        static private List<Thread> threads = new List<Thread>();
        // Делегат для доступа к textBox контроллам
        delegate void Del(string text);

        public MainForm()
        {
            InitializeComponent();

            statusConnection.Text = "Connected: Local Version";

            prop = new Propeties();
            if (File.Exists("propeties.cfg") == false)
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Propeties));
                System.IO.StreamWriter file = new System.IO.StreamWriter("propeties.cfg");
                prop.server = "127.0.0.1";
                prop.nickname = "Player";
                writer.Serialize(file, prop);
                file.Close();
            }
            else
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Propeties));
                System.IO.StreamReader file = new System.IO.StreamReader("propeties.cfg");
                prop = (Propeties)reader.Deserialize(file);
                file.Close();
            }
            client.initiateClient();
            Receiver();
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

        private void button1_Click(object sender, EventArgs e)
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

        private void compileMessage() {
            string message;
            message =prop.nickname + ": " + messageBox.Text;
            messageBox.Text = "";
            client.sendMessage(message);
        } 

        private void menuOptions_Click(object sender, EventArgs e)
        {
            OptionForm opForm = new OptionForm();
            opForm.ShowDialog();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
