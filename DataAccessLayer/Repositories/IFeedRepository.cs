using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Classes;

namespace DataAccessLayer.Repositories
{
    public interface IFeedRepository<T> where T : Feed
    {
        Task SaveFeedAsync(T instance, string fileName);
        Task<List<T>> GetListOfFeedsAsync(List<string> list);
        Task<Feed> GetFeedAsync(string fileName);
    }
}
