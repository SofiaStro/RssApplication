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
        public void CreateFeed()
        {

            Feed newFeed = null;
            //if (objectType.Equals("Podcast"))
            //{
            Class1 classf = new Class1();
            Category category = new Category("Humor");
                newFeed = new Podcast("NAMN", 30, 60, category, classf.GetFeed());
            //}
            ////if (objectType.Equals("Nyhet"))
            ////{
            //    newFeed = new News(name, numberOfEpisodes, timeInterval, category, listOfEpisodes);
            //}
            feedRepository.Create(newFeed);
        }
    }
}
