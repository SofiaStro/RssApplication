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
        public void CreateFeed(string namn, int numberOfEpisodes, int timeInterval)
        {
            Feed newFeed = null;
            Class1 lista = new Class1();
            Category category = new Category("Humor");
            //if (objectType.Equals("Podcast"))
            //{
            newFeed = new Podcast(namn, numberOfEpisodes, timeInterval, category, lista.GetFeed());
            //}
            //if (objectType.Equals("Nyhet"))
            //{
            //    newFeed = new News(name, numberOfEpisodes, timeInterval, category, listOfEpisodes);
            //}
            feedRepository.Create(newFeed);
        }
    }
}
