using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Podcast : Feed
    {
        public Podcast(string name, int numberOfEpisodes, int timeInterval,
               Category category, List<Episode> episodeList) :
               base(name, numberOfEpisodes, timeInterval, category, episodeList)
        {
        }

        public override string Display()
        {
            return base.Display() + "Podcast";
        }
    }
}
