﻿using System;
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

        public void GetFeed()
        {
            
            using (var webClient = new WebClient()) //Tillåter avläsning av webb-länkar
            {
                using (Stream fs = webClient.OpenRead("https://rss.acast.com/historiepodden")) //Öppnar en läsbar stream från data som är nedladdad från en källa
                {
                    XmlReader reader = XmlReader.Create(fs);
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                }
            }

        }
    }
}