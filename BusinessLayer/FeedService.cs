using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using Models.Classes;
using Models;

namespace BusinessLayer
{
    public class FeedService
    {
        IFeedRepository<Feed> feedRepository;

        public FeedService()
        {
            feedRepository = new FeedRepository();
        }
        public void CreateFeed(string name, int numberOfEpisodes, int timeInterval, 
                            Category category, List<Episode> listOfEpisodes )
        {
            listOfEpisodes = Class1.GetFeed();

            Feed newFeed = null;
            //if (objectType.Equals("Podcast"))
            //{
                newFeed = new Podcast(name, numberOfEpisodes, timeInterval, category, listOfEpisodes);
            //}
            ////if (objectType.Equals("Nyhet"))
            ////{
            //    newFeed = new News(name, numberOfEpisodes, timeInterval, category, listOfEpisodes);
            //}
            feedRepository.Create(newFeed);
        }
    }
}
