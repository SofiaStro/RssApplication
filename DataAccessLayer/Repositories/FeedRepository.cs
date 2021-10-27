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
            //SaveChanges(feedObject, fileName);
        }

        public void Update(int index, Feed feedObject)
        {
            if (index >= 0)
            {
                //listOfFeeds[index] = feedObject;
            }
            //SaveChanges();
        }

        public void Delete(int index)
        {
            //listOfFeeds.RemoveAt(index);
            //SaveChanges();
        }

        public void Save(Feed feedObject, string fileName)
        {
            serializerObject.Serializer(feedObject, fileName);
        }

        public List<Feed> GetCurrentFeeds(List<string> listFileNames)

        {

            List<Feed> listOfFeedsDeserialized = new List<Feed>();
            try
            {
                List<string> fileNames = listFileNames;
                foreach(string fileName in fileNames)
                {
                    listOfFeedsDeserialized.Add(serializerObject.Deserialize(fileName));
                }
                
            }
            catch (Exception)
            {
                throw new Exception();

            }

            return listOfFeedsDeserialized;
        }

        public Feed GetCurrentFeed(string fileName)
        {
            Feed feedObject;

            try
            {

                feedObject = serializerObject.Deserialize(fileName);
                

            }
            catch (Exception)
            {
                throw new Exception();

            }
            return feedObject;

        }

        public Feed GetByCategory(Category category)
        {
            throw new NotImplementedException();
        }

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
