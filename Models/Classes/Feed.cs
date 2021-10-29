using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models.Interfaces;

namespace Models.Classes
{
    [XmlInclude(typeof(Podcast))]
    [XmlInclude(typeof(News))]
    public abstract class Feed : INameable
    {
        [XmlElement(Order = 1)]
        public string Url { get; set; }
        [XmlElement(Order = 2)]
        public string Name { get; set; }
        [XmlElement(Order = 3)]
        public int NumberOfEpisodes { get; set; }
        [XmlElement(Order = 4)]
        public int TimeInterval { get; set; }
        [XmlElement(Order = 5)]
        public string Category;
        [XmlElement(Order = 7, ElementName = "Episode")]
        public List<Episode> ListOfEpisodes;
        [XmlElement(Order = 6)]
        public string FileName { get; set; }
        [XmlElement(Order = 8)]
        public string NextUpdate { get; set; }


        public Feed()
        {
        }
        public Feed(string url, string name, int numberOfEpisodes, int timeInterval, string category, 
            List<Episode> listOfEpisodes, string fileName)
        {
            Url = url;
            Name = name;
            NumberOfEpisodes = numberOfEpisodes;
            TimeInterval = timeInterval;
            Category = category;
            ListOfEpisodes = listOfEpisodes;
            FileName = fileName;
            Update();

        }

        public virtual string Display()
        {
            return "Här visas en beskrivning för ditt valda avsnitt för din: ";
        }

        public bool NeedsUpdate
        {
            get
            {
                DateTime nextUpdate = Convert.ToDateTime(NextUpdate);
                return nextUpdate <= DateTime.Now;
            }
        }

        public void Update()
        {
            int intervalMilliSeconds = TimeInterval * 60 * 1000;
            NextUpdate = DateTime.Now.AddMilliseconds(intervalMilliSeconds).ToString();
        }

    }
}
