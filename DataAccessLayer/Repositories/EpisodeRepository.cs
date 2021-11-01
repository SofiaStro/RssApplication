using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Models.Classes;
using System.Xml;
using System.ServiceModel.Syndication;

namespace DataAccessLayer.Repositories
{
    public class EpisodeRepository : IEpisodeRepository<Episode>
    {
        RssReader rssObject;

        public EpisodeRepository()
        {
            rssObject = new RssReader();
        }
     
        public async Task<List<Episode>> GetCurrentEpisodesAsync(string url)
        {
            List<Episode> listOfEpisodes = new List<Episode>();
            try
            {
                using (Stream stream = await rssObject.GetRSSAsync(url)) //Öppnar en läsbar stream från data som är nedladdad från en källa.
                {
                    XmlReader reader = XmlReader.Create(stream); // Skapar en "reader" som kan läsa av Xml-filer.
                    SyndicationFeed feed = SyndicationFeed.Load(reader); // Underlättar avläsning av RSS-flöden

                    foreach (SyndicationItem item in feed.Items)
                    {
                        string title = item.Title.Text;
                        string description = item.Summary.Text;
                        Episode episode = new Episode(title, description);
                        listOfEpisodes.Add(episode);
                    }
                }      
            }
            catch (Exception) { }

            return listOfEpisodes;
        }
    }
}
