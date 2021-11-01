using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Models.Classes;
using System.Xml.Serialization;

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
                    if (File.Exists(fileName)) // Kontrollerar om filnamnet redan finns och tar isådana fall bort filen med det namnet.
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
            catch (Exception) {}
        }

        public async Task<Feed> DeserializeAsync(string fileName)
        {
            Feed feed = null;
            try
            {
                await Task.Run(() =>
                {
                    XmlSerializer xmlReader = new XmlSerializer(typeof(Feed));
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Open,
                        FileAccess.Read))
                    {
                        feed = (Feed)xmlReader.Deserialize(fileStream);
                    }
                });
            }
            catch (Exception){}

            return feed;
        }

        public async Task CategorySerializerAsync(List<Category> listOfCategories)
        {
            try
            { 
                await Task.Run(() =>
                { 

                    XmlSerializer xmlWriter = new XmlSerializer(typeof(List<Category>));
                    using (FileStream fileStream = new FileStream("categoryObjects.xml", FileMode.Create, FileAccess.Write))
                    {
                        xmlWriter.Serialize(fileStream, listOfCategories);
                    }
                });
            }
            catch (Exception){}
        }

        public async Task<List<Category>> CategoryDeserializeAsync()
        {
            List<Category> listOfCategories = new List<Category>();

            try
            {
                await Task.Run(() =>
                {
                    if (File.Exists("categoryObjects.xml")) // Kontrollerar om filnamnet redan finns och tar isådana fall bort filen med det namnet.
                    {
                        XmlSerializer xmlReader = new XmlSerializer(typeof(List<Category>));
                        using (FileStream fileStream = new FileStream("categoryObjects.xml", FileMode.Open,
                            FileAccess.Read))
                        {
                            listOfCategories = (List<Category>)xmlReader.Deserialize(fileStream);
                        }
                    }
                });
            }
            catch (Exception) {}

            return listOfCategories;
        }
    }
}
