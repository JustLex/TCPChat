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

namespace Chat_Client
{
    public partial class OptionForm : Form
    {
        public static Propeties prop;
        public OptionForm()
        {
            InitializeComponent();
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            prop = new Propeties();
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Propeties));
            System.IO.StreamReader file = new System.IO.StreamReader("propeties.cfg");
            prop = (Propeties)reader.Deserialize(file);
            file.Close();
            serverTextBox.Text = prop.server;
            nicknameTextBox.Text = prop.nickname;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            prop.server = serverTextBox.Text;
            prop.nickname = nicknameTextBox.Text;

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Propeties));
            System.IO.StreamWriter file = new System.IO.StreamWriter("propeties.cfg");
            writer.Serialize(file, prop);
            file.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
