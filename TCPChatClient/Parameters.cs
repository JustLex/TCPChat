using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chat_Client
{
    /// <summary>
    /// Класс хранящий параметры клиента.
    /// </summary>
    public class Parameters 
    {
        /// <summary>
        /// Адрес сервера.
        /// </summary>
        public string server;
        /// <summary>
        /// Имя пользователя, отображаемое в чате.
        /// </summary>
        public string nickname;
        /// <summary>
        /// Порт передачи данных. 
        /// </summary>
        public int port;
        /// <summary>
        /// Включение/выключение шифровки сообщений.
        /// </summary>
        public bool encrypt;
        /// <summary>
        /// Путь к файлу-ключу.
        /// </summary>
        public string keyPath;

        /// <summary>
        /// Конструктор по умолчанию, задающий стандартные значения полей.
        /// </summary>
        public Parameters(){
            this.server = "127.0.0.1";
            this.nickname = "Player";
            this.port = 6667;
            this.encrypt = false;
        }
        /// <summary>
        /// Десериализация параметров из XML файла "properties.cfg". 
        /// </summary>
        /// <returns></returns>
        public static Parameters deserializeParams(){
            Parameters prop = new Parameters();
            if (File.Exists("properties.cfg") == false)
            {
                XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Parameters));
                using (StreamWriter file = new System.IO.StreamWriter("properties.cfg"))
                {
                    prop = new Parameters();
                    writer.Serialize(file, prop);
                }
            }
            else
            {
                try
                {
                    XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Parameters));
                    using (StreamReader file = new System.IO.StreamReader("properties.cfg"))
                    {
                        prop = (Parameters)reader.Deserialize(file);
                    }
                }
                catch {
                    File.Delete("properties.cfg");
                    deserializeParams();
                }
            }
            return prop;
        }
        /// <summary>
        /// Сериализация параметров в XML файл "properties.cfg"
        /// </summary>
        public void serializeParams() {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Parameters));
            using (StreamWriter file = new System.IO.StreamWriter("properties.cfg"))
            {
                writer.Serialize(file, this);
            }
        }
    }
}
