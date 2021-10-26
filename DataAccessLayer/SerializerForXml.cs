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
       
        public void Serializer(Feed listOfFeeds, string fileName)
        {
            try
            {
                if (File.Exists(fileName)) 
                {
                    File.Delete(fileName);
                }
                else
                {
                    XmlSerializer xmlWriter = new XmlSerializer(typeof(Feed));
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        xmlWriter.Serialize(fileStream, listOfFeeds);
                    }
                }
                    
               
            }
            catch (Exception)
            {
                throw new SerializerException(fileName, "Serializeringen av xml-filen misslyckades");
            }
        }

        public Feed Deserialize(string fileName)
        {
            try
            {
                XmlSerializer xmlReader = new XmlSerializer(typeof(Feed));
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open,
                    FileAccess.Read))
                {
                    return (Feed)xmlReader.Deserialize(fileStream);
                }
            }
            catch (Exception)
            {
                throw new SerializerException(fileName, "Deserializeringen av xml-filen misslyckades");
            }

        }
    }
}
