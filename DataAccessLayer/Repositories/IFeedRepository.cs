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
        Task SaveFeedAsync(T instance, string fileName);

        Task<List<T>> GetListOfFeedsAsync(List<string> list);
        Task<Feed> GetFeedAsync(string fileName);
    }
}
