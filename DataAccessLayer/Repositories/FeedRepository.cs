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
        public void Create(Feed entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public List<Feed> GetAll()
        {
            throw new NotImplementedException();
        }

        public Feed GetByCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Feed GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int GetIndex(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(int index, Feed entity)
        {
            throw new NotImplementedException();
        }
    }
}
