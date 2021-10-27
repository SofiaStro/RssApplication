using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

     
        public List<Episode> GetCurrentEpisodes(string url)
        {
            List<Episode> listOfEpisode = new List<Episode>();

                using (Stream fs = rssObject.GetRSS(url)) //Öppnar en läsbar stream från data som är nedladdad från en källa
                {
                    XmlReader reader = XmlReader.Create(fs);
                    SyndicationFeed feed = SyndicationFeed.Load(reader);

                    foreach (SyndicationItem item in feed.Items)
                    {
                        string title = item.Title.Text;
                        string description = item.Summary.Text;
                        Episode episode = new Episode(title, description);
                        listOfEpisode.Add(episode);
                    }
                }

                return listOfEpisode;
            

        }

    }
}
