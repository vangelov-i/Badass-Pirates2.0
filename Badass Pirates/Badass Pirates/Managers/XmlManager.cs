namespace Badass_Pirates.EngineComponents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class XmlManager<T>
    {
        public Type Tpye { get; set; }

        //public void Load(string xmlPath)
        //{
        //    var xmlDoc = new XmlDocument(); // Create an XML document object
        //    xmlDoc.Load(xmlPath);

        //    var list = xmlDoc.SelectNodes("TitleScreen");
        //    foreach (var VARIABLE in COLLECTION)
        //    {

        //    }
        //}




        public T Load(string path)
        {
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(this.Tpye);
                instance = (T)xml.Deserialize(reader);
            }

            return instance;
        }

        public void Save(string path, object obj)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(this.Tpye);
                xml.Serialize(writer, obj);
            }
        }


    }
}
