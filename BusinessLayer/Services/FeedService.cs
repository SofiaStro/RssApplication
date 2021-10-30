using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using Models.Classes;
using Models;
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


        //public string SetNewFileName()
        //{
        //    int number;
        //    string fileName;
        //    List<string> listFileNames = GetFileNameList();
        //    if (listFileNames.Count == 0)
        //    {
        //        number = 0;
        //    }
        //    else
        //    {
        //        string latestFileName = listFileNames.Last();
        //        number = Convert.ToInt32(latestFileName.Substring(latestFileName.Length - 5, 1));
        //        number++;
        //    }
        //    fileName = "feed" + Convert.ToString(number) + ".xml";
        
        //    return fileName;
        //}

        //public List<string> GetFileNameList()
        //{
        //    string localPath = Directory.GetCurrentDirectory();
        //    List<string> fileNames = Directory.GetFiles(localPath, "feed*.xml").ToList();
        //    //List<string> fileNames = Directory.GetFiles(@"C:\Users\moahe\OneDrive\Dokument\GitHub\RssApplication\RssApplication\bin\Debug", "*.xml").ToList();

        //    return fileNames;

        //}
        public async Task CreateFeedAsync(string url, string name, int timeInterval, string category, string type)
        {
            Feed newFeed = null;

            
            List<Episode> listOfEpisodes = await episodeService.GetListOfEpisodesAsync(url);
            int numberOfEpisodes = episodeService.NumberOfEpisodes(listOfEpisodes);

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
        }

        public async Task ChangeFeedAsync(string newName, int newTimeInterval, string newCategory, string fileName)
        {
            Feed oldFeed = await feedRepository.GetFeedAsync(fileName);
            Feed newFeed = null;

            string url = oldFeed.Url;
            string name = newName;
            int numberOfEpisodes = Convert.ToInt32(oldFeed.NumberOfEpisodes);
            int timeInterval = newTimeInterval;
            string category = newCategory;
            List<Episode> listOfEpisodes = await episodeService.GetListOfEpisodesAsync(url); 

            if(oldFeed is Podcast)
            {
                newFeed = new Podcast(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
            }
            else if(oldFeed is News)
            {
                newFeed = new Podcast(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
            }

            await feedRepository.SaveFeedAsync(newFeed, fileName);
        }
        
        public void DeleteFeed(string fileName)
        {
            File.Delete(fileName);
        }

        public async Task<List<Feed>> GetListOfFeedsAsync()
        {
            List<string> listFileNames = fileNameService.GetFileNameList();
            List<Feed> listOfFeeds = await feedRepository.GetListOfFeedsAsync(listFileNames);
            //Feed name = null;
            ////string name = Convert.ToString(listOfFeeds.Select(listOfFeed => listOfFeed.Name));
            //foreach (Feed item in listOfFeeds)
            //{
            //    name = item;
            //}


            return listOfFeeds;
        }

        public async Task<Feed> GetFeedAsync (string fileName)
        {

            //List<Feed> listOfFeeds = DisplayFeed();
            //Feed feedObject = null;
            Feed feedObject = await feedRepository.GetFeedAsync(fileName);

            //foreach (Feed item in listOfFeeds)

            //{
            //    if (fileName.Equals(item.FileName))
            //    {
            //        feedObject = item;
            //    }

            //}
            return feedObject;
        }

        public async Task<List<Feed>> GetFeedInCategoryAsync(string filterCategory)
        {
            List<Feed> listOfFeedInCategory = new List<Feed>();
            List<Feed> listOfFeeds = await GetListOfFeedsAsync();
         
            List<Feed> listOfFeedCategorys = listOfFeeds.Where(feed => feed.Category == filterCategory).ToList();
            //foreach (Feed item in listOfFeeds)
            //{
            //    string inCategory = item.Category;
            //    if (inCategory.Equals(filterCategory))
            //    {
            //        listOfFeedInCategory.Add(item);
            //    }
            //}
            //return listOfFeedInCategory;
            return listOfFeedCategorys;
        }
    }
}
