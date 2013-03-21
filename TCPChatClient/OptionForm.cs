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
        /// <summary>
        /// Параметры клиента.
        /// </summary>
        public static Parameters prop;
        /// <summary>
        /// Конструктор окна настроек.
        /// </summary>
        /// <param name="param"> Параметры клиента.</param>
        public OptionForm(Parameters param)
        {
            InitializeComponent();
            prop = param;
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            fillBoxes();
            if (encryptCheckBox.Checked == false)
            {
                keyTextBox.Enabled = false;
                keyTextBox.BackColor = Color.LightGray;
                keyTextBox.Text = "";
            }
        }

        /// <summary>
        /// Проверка полей формы на корректность.
        /// </summary>
        /// <returns></returns>
        private bool checkBoxes()
        {
            string port = portTextBox.Text;
            try
            {
                int intPort = Convert.ToInt32(portTextBox.Text);
                if (!(intPort >= 0 && intPort <= 9999)) throw new Exception("Порт должен быть целым числом от 0 до 9999");
                
                IPAddress tryIp;
                if (!IPAddress.TryParse(serverTextBox.Text, out tryIp)) throw new Exception("Некорректный IP сервера");
            } 
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "MEGACHAT");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Заполнение полей формы, используя данные из Parameters prop.
        /// </summary>
        private void fillBoxes()
        {
            serverTextBox.Text = prop.server;
            nicknameTextBox.Text = prop.nickname;
            portTextBox.Text = Convert.ToString(prop.port);
            encryptCheckBox.Checked = prop.encrypt;
            keyTextBox.Text = prop.keyPath;

        }

        /// <summary>
        /// Загрузка значений из полей формы в Parameters prop.
        /// </summary>
        private void loadParameters()
        {
            prop.server = serverTextBox.Text;
            prop.nickname = nicknameTextBox.Text;
            prop.port = Convert.ToInt32(portTextBox.Text);
            prop.encrypt = encryptCheckBox.Checked;
            prop.keyPath = keyTextBox.Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (checkBoxes() == false) return;
            loadParameters();
            prop.serializeParams();
            DialogResult = DialogResult.OK;

        }

        private void keyTextBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                keyTextBox.Text = openFile.FileName;
            }
        }

        private void encryptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (encryptCheckBox.Checked == false)
            {
                keyTextBox.Enabled = false;
                keyTextBox.BackColor = Color.LightGray;
                keyTextBox.Text = "";
            }
            if (encryptCheckBox.Checked == true)
            {
                keyTextBox.Enabled = true;
                keyTextBox.BackColor = Color.White;
            }
        }


    }
}
