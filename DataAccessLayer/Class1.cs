using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccessLayer
{
    public class Class1
    {
        public void GetFeed()
        {
            
            using (var webClient = new WebClient()) //Tillåter avläsning av webb-länkar
            {
                using (Stream fs = webClient.OpenRead("https://rss.acast.com/historiepodden")) //Öppnar en läsbar stream från data som är nedladdad från en källa
                {
                    XmlReader reader = XmlReader.Create(fs);
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                }
            }

        }
    }
}
