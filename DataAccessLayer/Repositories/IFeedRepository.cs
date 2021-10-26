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

        List<T> GetCurrentFeeds(List<string> list);
    }
}
