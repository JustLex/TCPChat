using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Chat_Client
{
    /// <summary>
    /// Класс сообщения отправляемый на сервер и получаемый клиентом.
    /// </summary>
    [Serializable]
    class Message
    {
        /// <summary>
        /// Текст сообщения.
        /// </summary>
        private string _data;
        
        /// <summary>
        /// Отправитель сообщения.
        /// </summary>
        private string _owner;

        /// <summary>
        /// Дата отправки сообщения.
        /// </summary>
        private DateTime _time;

        /// <summary>
        /// Индикатор зашифрованности сообщения.
        /// </summary>
        public bool isEncrypted;

        /// <summary>
        /// Конструктор получающий byte[]. Используется для десериализации.
        /// </summary>
        /// <param name="source"> Сериализованный массив байтов - источник.</param>
        public Message(byte[] source)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();

            memStream.Write(source, 0, source.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Message tmp;
            tmp = (Message)binForm.Deserialize(memStream);
            
            _data = tmp._data;
            _owner = tmp._owner;
            _time = tmp._time;
            isEncrypted = tmp.isEncrypted;
            
        }

        /// <summary>
        /// Конструктор с параметрами (string, string, DateTime).
        /// </summary>
        /// <param name="_data"> Текст сообщения. </param>
        /// <param name="_owner"> Отправитель. </param>
        /// <param name="_time"> Дата. </param>
        public Message(string data, string owner, DateTime time)
        {
            _data = data;
            _owner = owner;
            _time = time;
        }


        /// <summary>
        /// Cериализация сообщения в byte[].
        /// </summary>
        /// <returns></returns>
        public byte[] serialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, this);
            return ms.ToArray();
        }

        /// <summary>
        /// Преобразовывает поле сообщения в зашифрованное по ключу.
        /// </summary>
        /// <param name="key">Путь к файлу-ключу шифрования.</param>
        public void encrypt(string keyPath)
        {
            int A = 0;
            int B = 0;
            int controlNumber = 0;
            string encryptedMsg = "";
            for (int i = 0; i < keyPath.Length; i++) A += keyPath[i];
            for (int i = 0; i < _owner.Length; i++) B += _owner[i];

            controlNumber = _time.Millisecond * A + _time.Second * B;

            for (int i = 0; i < _data.Length; i++)
            {
                int currentNumber = _data[(i + controlNumber) % _data.Length] + keyPath[(i * A) % keyPath.Length] + _owner[(i * B) % _owner.Length];
                encryptedMsg += Convert.ToChar(currentNumber);
            }

            _data = encryptedMsg;
            this.isEncrypted = true;
        }
        /// <summary>
        /// Преобразовывает поле сообщения в рашифрованное по ключу.
        /// </summary>
        /// <param name="key">Путь к файлу-ключу шифрования.</param>
        public void decrypt(string keyPath)
        {
            int A = 0;
            int B = 0;
            int controlNumber = 0;
            char[] decryptedMsg = new char[_data.Length];
            for (int i = 0; i < keyPath.Length; i++) A += keyPath[i];
            for (int i = 0; i < _owner.Length; i++) B += _owner[i];

            controlNumber = _time.Millisecond * A + _time.Second * B;

            for (int i = 0; i < _data.Length; i++)
            {
                int currentNumber = _data[i] - keyPath[(i * A) % keyPath.Length] - _owner[(i * B) % _owner.Length];
                if (currentNumber < 0) currentNumber = 12;
                decryptedMsg[(i + controlNumber) % _data.Length] = Convert.ToChar(currentNumber);
            }

            string ret = "";
            for (int i = 0; i < _data.Length; i++)
            {
                ret += decryptedMsg[i];
            }
            _data = ret;
            isEncrypted = false;
        }
        /// <summary>
        /// Возвращает форматированное сообщения в виде "[Дата] Отправитель : Сообщение".
        /// </summary>
        /// <returns></returns>
        public string make()
        {
            return ("[" + _time.ToString() + "] " + _owner + " : " + _data);
        }

    }
}
