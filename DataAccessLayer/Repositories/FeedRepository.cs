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
        SerializerForXml dataManager;
        List<Feed> listOfFeed;

        public FeedRepository()
        {
            dataManager = new SerializerForXml();
            listOfFeed = new List<Feed>();
            // listOfFeed = GetAll();
        }

        public void Create(Feed entity)
        {
            listOfFeed.Add(entity);
            SaveChanges();
        }

        public void Delete(int index)
        {
            listOfFeed.RemoveAt(index);
            SaveChanges();
        }

        //public List<Feed> GetAll()
        //{
        //    List<Feed> 
        //}

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
            dataManager.Serializer(listOfFeed);
        }

        public void Update(int index, Feed entity)
        {
            if(index >= 0)
            {
                listOfFeed[index] = entity;
            }
            SaveChanges();
        }
    }
}
