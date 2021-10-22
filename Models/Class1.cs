using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Models.Classes;

namespace Models
{
    public class Class1
    {

        public List<Episode> GetFeed()
        {
            List<Episode> listOfEpisode = new List<Episode>(); 

            using (var webClient = new WebClient()) //Tillåter avläsning av webb-länkar
            {
                using (Stream fs = webClient.OpenRead("https://rss.acast.com/historiepodden")) //Öppnar en läsbar stream från data som är nedladdad från en källa
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
            }
            return listOfEpisode;
        }
    }
}
