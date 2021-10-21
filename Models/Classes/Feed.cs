using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public abstract class Feed : Interfaces.INameable
    {
        public string Name { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int TimeInterval { get; set; }

        public Category Category;

        public List<Episode> EpisodeList;

        public Feed(string name, int numberOfEpisodes, int timeInterval, 
                   Category category , List<Episode> episodeList)
        {
            Name = name;
            NumberOfEpisodes = numberOfEpisodes;
            TimeInterval = timeInterval;
            Category = category;
            EpisodeList = episodeList;

        }

        public virtual string Display()
        {
            return "Det här är en: ";
        }

    }
}
