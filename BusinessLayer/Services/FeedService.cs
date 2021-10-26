using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using Models.Classes;
using Models;

namespace BusinessLayer.Services
{
    public class FeedService
    {
        IFeedRepository<Feed> feedRepository;


        public FeedService()
        {
            feedRepository = new FeedRepository();

        }

        public int Count { get; set; }

        public string GetFileName()
        {
            string fileName;
            fileName = "feed" + Convert.ToString(Count) + ".xml";
            Count++;

            return fileName;
        }
        public void CreateFeed(string url, string name, int timeInterval, string category, string type)
        {
            Feed newFeed = null;

            EpisodeService episodeService = new EpisodeService();
            List<Episode> listOfEpisodes = episodeService.GetListOfEpisodes(url);
            int numberOfEpisodes = episodeService.NumberOfEpisodes(listOfEpisodes);

            string fileName = GetFileName();

            if (type.Equals("Podcast"))
            {
                newFeed = new Podcast(name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
            }
            else if (type.Equals("Nyhet"))
            {
                newFeed = new News(name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
            }

            feedRepository.Create(newFeed, fileName);
        }

        public List<Feed> DisplayFeed()
        {
            List<Feed> listOfFeeds = feedRepository.GetCurrentFeeds();
            //Feed name = null;
            ////string name = Convert.ToString(listOfFeeds.Select(listOfFeed => listOfFeed.Name));
            //foreach (Feed item in listOfFeeds)
            //{
            //    name = item;
            //}

            return listOfFeeds;
        }
    }
}
