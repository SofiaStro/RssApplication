using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;

namespace DataAccessLayer.Repositories
{
    public class FeedRepository : IFeedRepository<Feed>
    {
        SerializerForXml serializerObject;
        List<Feed> listOfFeeds;

        public FeedRepository()
        {
            serializerObject = new SerializerForXml();
            listOfFeeds = new List<Feed>();
            listOfFeeds = GetCurrentFeeds();
        }

        public void Create(Feed feedObject)
        {
            listOfFeeds.Add(feedObject);
            SaveChanges();
        }

        public void Delete(int index)
        {
            listOfFeeds.RemoveAt(index);
            SaveChanges();
        }

        public List<Feed> GetCurrentFeeds()
        {
            List<Feed> listOfFeedsDeserialized = new List<Feed>();
            try
            {
                listOfFeedsDeserialized = serializerObject.Deserialize();
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
        //    throw new NotImplementedException();
        //}

        public void SaveChanges()
        {
            serializerObject.Serializer(listOfFeeds);
        }

        public void Update(int index, Feed feedObject)
        {
            if(index >= 0)
            {
                listOfFeeds[index] = feedObject;
            }
            SaveChanges();
        }
    }
}
