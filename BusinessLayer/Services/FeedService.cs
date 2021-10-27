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


        public FeedService()
        {
            feedRepository = new FeedRepository();

        }


        public string SetNewFileName()
        {
            int number;
            string fileName;
            List<string> listFileNames = GetFileNameList();
            if (listFileNames.Count == 0)
            {
                number = 0;
            }
            else
            {
                string latestFileName = listFileNames.Last();
                number = Convert.ToInt32(latestFileName.Substring(latestFileName.Length - 5, 1));
                number++;
            }
            fileName = "feed" + Convert.ToString(number) + ".xml";
        
            return fileName;
        }

        public List<string> GetFileNameList()
        {
            string localPath = Directory.GetCurrentDirectory();
            List<string> fileNames = Directory.GetFiles(localPath, "feed*.xml").ToList();
            //List<string> fileNames = Directory.GetFiles(@"C:\Users\moahe\OneDrive\Dokument\GitHub\RssApplication\RssApplication\bin\Debug", "*.xml").ToList();

            return fileNames;

        }
        public void CreateFeed(string url, string name, int timeInterval, string category, string type)
        {
            Feed newFeed = null;

            EpisodeService episodeService = new EpisodeService();
            List<Episode> listOfEpisodes = episodeService.GetListOfEpisodes(url);
            int numberOfEpisodes = episodeService.NumberOfEpisodes(listOfEpisodes);

            string fileName = SetNewFileName();

            if (type.Equals("Podcast"))
            {
                newFeed = new Podcast(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
            }
            else if (type.Equals("Nyhet"))
            {
                newFeed = new News(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName);
            }

            feedRepository.Save(newFeed, fileName);
        }

        public void ChangeFeed(string url, string name, int timeInterval, string category, string fileName)
        {
            Feed oldFeed = feedRepository.GetCurrentFeed(fileName);
            //string url = oldFeed.Url;
            string newName;
            int newTimeInterval;
            string newCategory;


            if (name != "") { newName = name; }
            else { newName = oldFeed.Name; }

            if (timeInterval != null) { newName = name; }
            else { newName = oldFeed.Name; }

            if (name != "") { newName = name; }
            else { newName = oldFeed.Name; }

            if (name != "") { newName = name; }
            else { newName = oldFeed.Name; }

            //Feed newFeed = new Feed()
        }
        
        public void DeleteFeed(string fileName)
        {
            File.Delete(fileName);
        }

        public List<Feed> DisplayFeed()
        {
            List<string> listFileNames = GetFileNameList();
            List<Feed> listOfFeeds = feedRepository.GetCurrentFeeds(listFileNames);
            //Feed name = null;
            ////string name = Convert.ToString(listOfFeeds.Select(listOfFeed => listOfFeed.Name));
            //foreach (Feed item in listOfFeeds)
            //{
            //    name = item;
            //}

            return listOfFeeds;
        }

        public Feed CompareFeedObjects (string fileName)
        {

            List<Feed> listOfFeeds = DisplayFeed();
            Feed feedObject = null;
            //Feed feedObject = feedRepository.GetCurrentFeed(fileName);

            foreach (Feed item in listOfFeeds)

            {
                if (fileName.Equals(item.FileName))
                {
                    feedObject = item;
                }

            }
            return feedObject;
        }
    }
}
