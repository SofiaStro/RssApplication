using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Models.Interfaces;

namespace Models.Classes
{
    [XmlInclude(typeof(Podcast))]
    [XmlInclude(typeof(News))]
    public abstract class Feed : INameable
    {
        [XmlElement(Order = 1)] // Anger ordningen på elementet i Xml-filen.
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

        public Feed() { } // En tom konstuktor för att kunna serialisera/deserialisera objectet. 

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
            UpdateFeedContent();
        }

        public virtual string Display()
        {
            return "Här visas en beskrivning för ditt valda avsnitt för din: ";
        }

        public bool FeedNeedsUpdate
        {
            get
            {
                DateTime nextUpdate = Convert.ToDateTime(NextUpdate);
                return nextUpdate <= DateTime.Now; // Kontrollerar om uppdateringstiden stämmer med nuvarande tidspunkt. Returnerar true/false.
            }
        }

        public void UpdateFeedContent()
        {
            int intervalMilliSeconds = TimeInterval * 60 * 1000; // Tidintervall som anges i minuter räknas om till millisekunder. 
            NextUpdate = DateTime.Now.AddMilliseconds(intervalMilliSeconds).ToString(); // Skapar tiden då objektet ska uppdateras nästa gång. 
        }
    }
}
