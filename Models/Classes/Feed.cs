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
    //[XmlInclude(typeof(News))]
    public abstract class Feed : INameable
    {
        public string Name { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int TimeInterval { get; set; }

        //public Category Category;

        //public List<Episode> ListOfEpisodes;
        public Feed()
        {
        }
        public Feed(string name, int numberOfEpisodes, int timeInterval)
        {
            Name = name;
            NumberOfEpisodes = numberOfEpisodes;
            TimeInterval = timeInterval;
            //Category = category;
            //ListOfEpisodes = listOfEpisodes;

        }

        public virtual string Display()
        {
            return "Det här är en: ";
        }

    }
}
