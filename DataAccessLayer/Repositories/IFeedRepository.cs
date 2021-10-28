using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;

namespace DataAccessLayer.Repositories
{
    public interface IFeedRepository<T> : IRepository<T> where T : Feed
    {


        //T GetByName(string name);

        //T GetByCategory(Category category);

        //int GetIndex(string name);
        //void Create(T instance, string fileName);
        void SaveFeed(T instance, string fileName);

        List<T> GetListOfFeeds(List<string> list);
        Feed GetFeed(string fileName);
    }
}
