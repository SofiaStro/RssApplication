using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using Models.Classes;

namespace BusinessLayer.Services
{
    
    public class EpisodeService
    {
        IEpisodeRepository<Episode> episodeRepository;

        public EpisodeService()
        {

            episodeRepository = new EpisodeRepository();
        }

        public List<Episode> GetListOfEpisodes(string url)
        {
            List<Episode> listOfEpisodes = episodeRepository.GetCurrentEpisodes(url);

            return listOfEpisodes;
        }

        public int NumberOfEpisodes(List<Episode> listOfEpisodes)
        {
            int counter = 0;

            foreach(Episode episode in listOfEpisodes)
            {
                counter++;
            }

            return counter;
        }
    }
}
