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
        private bool isEncrypted;

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
        /// <param name="key">Ключ шифрования.</param>
        public void encrypt(int key)
        {

        }
        /// <summary>
        /// Преобразовывает поле сообщения в рашифрованное по ключу.
        /// </summary>
        /// <param name="key">Ключ шифрования.</param>
        public void decrypt(int key)
        {

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
