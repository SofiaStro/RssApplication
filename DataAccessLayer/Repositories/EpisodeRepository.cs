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

                using (Stream fs = await rssObject.GetRSSAsync(url)) //Öppnar en läsbar stream från data som är nedladdad från en källa
                {
                    XmlReader reader = XmlReader.Create(fs);
                    SyndicationFeed feed = SyndicationFeed.Load(reader);

                    foreach (SyndicationItem item in feed.Items)
                    {
                        string title = item.Title.Text;
                        string description = item.Summary.Text;
                        Episode episode = new Episode(title, description);
                        listOfEpisodes.Add(episode);
                    }
<<<<<<< Updated upstream
                }      
            }
            catch (Exception) { }
            return listOfEpisode;
=======
                }
            }
            catch (Exception) {}

            return listOfEpisodes;
>>>>>>> Stashed changes
        }

    }
}
