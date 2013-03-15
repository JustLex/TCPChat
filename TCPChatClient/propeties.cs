using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chat_Client
{
    public class Parameters
    {
        public string server;
        public string nickname;
        public int port;

        public Parameters(){
            this.server = "127.0.0.1";
            this.nickname = "Player";
            this.port = 6667;
        }

        public static Parameters deserializeParams(){
            Parameters prop = new Parameters();
            if (File.Exists("propeties.cfg") == false)
            {
                XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Parameters));
                using (StreamWriter file = new System.IO.StreamWriter("propeties.cfg"))
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
                    using (StreamReader file = new System.IO.StreamReader("propeties.cfg"))
                    {
                        prop = (Parameters)reader.Deserialize(file);
                    }
                }
                catch {
                    File.Delete("propeties.cfg");
                    deserializeParams();
                }
            }
            return prop;
        }

        public void serializeParams() {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Parameters));
            using (StreamWriter file = new System.IO.StreamWriter("propeties.cfg")){
                writer.Serialize(file, this);
            }
        }
    }
}
