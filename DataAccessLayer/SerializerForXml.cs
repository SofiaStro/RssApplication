using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Models.Classes;
using System.Xml.Serialization;
using DataAccessLayer.Exceptions;

namespace DataAccessLayer
{
    internal class SerializerForXml
    {
        private int count = 0;

        public string GetFileName()
        {
            string fileName;
            fileName = "feed" + Convert.ToString(count) + ".xml";
            count++;

            return fileName;
        }
        public void Serializer(List<Feed> listOfFeeds)
        {
            try
            {

                if (File.Exists("feedObjects.xml"))                     
                {
                    //File.Delete("feedObjects.xml");
                    XmlSerializer xmlWriter = new XmlSerializer(typeof(List<Feed>));
                    using (FileStream fileStream = new FileStream("feedObjects.xml", FileMode.Create, FileAccess.Write))
                    {
                        xmlWriter.Serialize(fileStream, listOfFeeds);
                    }
                }
                //else
                //{
                //    XmlSerializer xmlWriter = new XmlSerializer(typeof(List<Feed>));
                //    using (FileStream fileStream = new FileStream("feedObjects.xml", FileMode.OpenOrCreate, FileAccess.Write))
                //    {
                //        xmlWriter.Serialize(fileStream, listOfFeeds);
                //    }
                //}
            }
            catch (Exception)
            {
                throw new SerializerException("feedObjects.xml", "Serializeringen av xml-filen misslyckades");
            }
        }

        public List<Feed> Deserialize()
        {
            try
            {
                XmlSerializer xmlReader = new XmlSerializer(typeof(List<Feed>));
                using (FileStream fileStream = new FileStream("feedObjects.xml", FileMode.Open,
                    FileAccess.Read))
                {
                    return (List<Feed>)xmlReader.Deserialize(fileStream);
                }
            }
            catch (Exception)
            {
                throw new SerializerException("feedObjects.xml", "Deserializeringen av xml-filen misslyckades");
            }

        }
    }
}
