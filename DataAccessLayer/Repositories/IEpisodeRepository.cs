using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Classes;

namespace DataAccessLayer.Repositories
{
    public interface IEpisodeRepository<T> where T : Episode
    {
        Task<List<T>> GetCurrentEpisodesAsync(string url);
    }
}
