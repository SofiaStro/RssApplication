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

namespace DataAccessLayer
{
    internal class SerializerForXml
    {

        public void Serializer(List<Feed> listOfFeed)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Feed>));
                using (FileStream fileStream = new FileStream("feedObj.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    xmlSerializer.Serialize(fileStream, listOfFeed);
                }
            }
            catch(Exception e)
            {
               
            }
        }
    }
}
