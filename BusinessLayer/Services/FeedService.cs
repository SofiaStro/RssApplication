using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using Models.Classes;
using System.IO;

namespace BusinessLayer.Services
{
    public class FeedService
    {
        IFeedRepository<Feed> feedRepository;
        EpisodeService episodeService;
        FileNameService fileNameService;


        public FeedService()
        {
            feedRepository = new FeedRepository();
            episodeService = new EpisodeService();
            fileNameService = new FileNameService();
        }

        public async Task CreateFeedAsync(string url, string name, int timeInterval, string category, string type)
        {

            try
            {   Feed newFeed = null;

                List<Episode> listOfEpisodes = await episodeService.GetListOfEpisodesAsync(url);
                int numberOfEpisodes = episodeService.GetNumberOfEpisodes(listOfEpisodes);
                
                string fileName = fileNameService.SetNewFileName();

                if (type.Equals("Podcast"))
                {
                    newFeed = new Podcast(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
                }
                else if (type.Equals("Nyhet"))
                {
                    newFeed = new News(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
                }

                await feedRepository.SaveFeedAsync(newFeed, fileName);
            } catch (Exception) { }

        }

        public async Task ChangeFeedAsync(string newName, int newTimeInterval, string newCategory, string fileName)
        {
            try
            {
                Feed oldFeed = await feedRepository.GetFeedObjectAsync(fileName);
                Feed newFeed = null;

                string url = oldFeed.Url;
                string name = newName;
                int numberOfEpisodes = Convert.ToInt32(oldFeed.NumberOfEpisodes);
                int timeInterval = newTimeInterval;
                string category = newCategory;
                List<Episode> listOfEpisodes = await episodeService.GetListOfEpisodesAsync(url);

                if (oldFeed is Podcast)
                {
                    newFeed = new Podcast(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
                }
                else if (oldFeed is News)
                {
                    newFeed = new News(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
                }

                await feedRepository.SaveFeedAsync(newFeed, fileName);
            } catch(Exception) { }
        }
        
        public void DeleteFeed(string fileName)
        {
            File.Delete(fileName);
        }

        public async Task<List<Feed>> GetListOfFeedsAsync()
        {
            List<Feed> listOfFeeds = new List<Feed>();
            try
            {
                List<string> listFileNames = fileNameService.GetFileNameList();
                listOfFeeds = await feedRepository.GetListOfFeedsAsync(listFileNames);
            } catch(Exception) { }

            return listOfFeeds;
        }

        public async Task<Feed> GetFeedAsync (string fileName)
        {
            Feed feedObject = await feedRepository.GetFeedObjectAsync(fileName);
            return feedObject;
        }

        public async Task<List<Feed>> GetFeedInCategoryAsync(string filterCategory)
        {
            List<Feed> listOfFeedInCategory = new List<Feed>();
            List<Feed> listOfFeeds = await GetListOfFeedsAsync();

            List<Feed> listOfFeedCategories = listOfFeeds.Where(feed => feed.Category.Equals(filterCategory)).ToList();

            return listOfFeedCategories;
        } 

        public string DisplayFeedType(Feed feedObject)
        {
            string feedType = feedObject.Display();
            return feedType;
        }
    }
}
