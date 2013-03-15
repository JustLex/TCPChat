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

namespace Chat_Client
{
    public partial class OptionForm : Form
    {
        public static Parameters prop;
        private string oldIP;

        public OptionForm(Parameters param)
        {
            InitializeComponent();
            prop = param;
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            serverTextBox.Text = prop.server;
            nicknameTextBox.Text = prop.nickname;
            oldIP = prop.server;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            IPAddress tryIp;
            if (IPAddress.TryParse(serverTextBox.Text, out tryIp))
            {
                prop.server = serverTextBox.Text;
                prop.nickname = nicknameTextBox.Text;
                oldIP = prop.server;
                prop.serializeParams();
                DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show("Invalid IP address");
                serverTextBox.Text = oldIP;
            }
        }
    }
}
