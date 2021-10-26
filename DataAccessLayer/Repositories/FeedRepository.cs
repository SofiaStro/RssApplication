using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;

namespace DataAccessLayer.Repositories
{
    public class FeedRepository : IFeedRepository<Feed>
    {
        SerializerForXml serializerObject;
        //List<Feed> listOfFeeds;
        

        public FeedRepository()
        {
            serializerObject = new SerializerForXml();
            //listOfFeeds = new List<Feed>();
            //listOfFeeds = GetCurrentFeeds();
        }

        public void Create(Feed feedObject, string fileName)
        {
            //listOfFeeds.Add(feedObject);
            SaveChanges(feedObject, fileName);
        }

        //public void Update(int index, Feed feedObject)
        //{
        //    if (index >= 0)
        //    {
        //        listOfFeeds[index] = feedObject;
        //    }
        //    SaveChanges();
        //}

        //public void Delete(int index)
        //{
        //    listOfFeeds.RemoveAt(index);
        //    SaveChanges();
        //}

        public void SaveChanges(Feed feedObject, string fileName)
        {
            serializerObject.Serializer(feedObject, fileName);
        }

       public string[] GetFileNames()
        {
            //List<String> fileNames = new List<string> { "feed2.xml", "feed4.xml", "feed5.xml" };

            string[] fileNames = new string[3];
            fileNames = Directory.GetFiles(@"C:\Users\strom\OneDrive\Skrivbord\ht21-oru-informatik-fort\IK202G-op-cSharp\RssApplication\RssApplication\RssApplication\bin\Debug", "*.xml");

            return fileNames;
        }

        public List<Feed> GetCurrentFeeds()
        {
            List<Feed> listOfFeedsDeserialized = new List<Feed>();
            try
            {
                string[] fileNames = GetFileNames();
                foreach(string fileName in fileNames)
                {
                    listOfFeedsDeserialized.Add(serializerObject.Deserialize(fileName));
                }
                
            }
            catch (Exception)
            {
                //FIXA DENNA!! 

            }

            return listOfFeedsDeserialized;
        }

        //public Feed GetByCategory(Category category)
        //{
        //    throw new NotImplementedException();
        //}

        //public Feed GetByName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        //public int GetIndex(string name)
        //{

        //    return GetCurrentFeeds().FindIndex(e => e.Name.Equals(name));

        //}


    }
}
