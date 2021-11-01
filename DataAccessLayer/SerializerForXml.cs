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
using Models.Exceptions;
using System.Threading;

namespace DataAccessLayer
{
    internal class SerializerForXml
    {
        public async Task SerializerAsync(Feed listOfFeeds, string fileName)
        {
            try
            {
                await Task.Run(() =>
                {
                    if (File.Exists(fileName)) 
                    {
                        File.Delete(fileName);
                    }
                    
                    XmlSerializer xmlWriter = new XmlSerializer(typeof(Feed));
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        xmlWriter.Serialize(fileStream, listOfFeeds);
                    }
                });           
            }
            catch (Exception)
            {
                throw new SerializerException(fileName, "Serializeringen av xml-filen misslyckades");
            }
        }

        public async Task<Feed> DeserializeAsync(string fileName)
        {
            try
            {
                return await Task.Run(() =>
                {
                    XmlSerializer xmlReader = new XmlSerializer(typeof(Feed));
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Open,
                        FileAccess.Read))
                    {
                        return (Feed)xmlReader.Deserialize(fileStream);
                    }
                });
            }
            catch (Exception)
            {
                throw new SerializerException(fileName, "Deserializeringen av xml-filen misslyckades");
            }
        }

        public async Task CategorySerializerAsync(List<Category> listOfCategorys)
        {
            try
            { 
                await Task.Run(() =>
                { 
                    XmlSerializer xmlWriter = new XmlSerializer(typeof(List<Category>));
                    using (FileStream fileStream = new FileStream("categoryObjects.xml", FileMode.Create, FileAccess.Write))
                    {
                        xmlWriter.Serialize(fileStream, listOfCategorys);
                    }
                });
            }
            catch (Exception)
            {
                throw new SerializerException("categoryObjects.xml", "Serializeringen av xml-filen misslyckades");
            }
        }

        public async Task<List<Category>> CategoryDeserializeAsync()
        {
            try
            {
                return await Task.Run(() =>
                {
                    XmlSerializer xmlReader = new XmlSerializer(typeof(List<Category>));
                    using (FileStream fileStream = new FileStream("categoryObjects.xml", FileMode.Open,
                        FileAccess.Read))
                    {
                        return (List<Category>)xmlReader.Deserialize(fileStream);
                    }
                });
            }
            catch (Exception)
            {
                throw new SerializerException("categoryObjects.xml", "Deserializeringen av xml-filen misslyckades");
            }
        }
    }
}
