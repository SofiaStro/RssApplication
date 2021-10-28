using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;

namespace DataAccessLayer.Repositories
{
    public interface IEpisodeRepository<T> where T : Episode
    {
        Task<List<T>> GetCurrentEpisodesAsync(string url);
    }
}
