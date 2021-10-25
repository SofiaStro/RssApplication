using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Podcast : Feed
    {
        public Podcast()
        {
        }

        public Podcast(string name, int numberOfEpisodes, int timeInterval, Category category, List<Episode> listOfEpisodes) :
               base(name, numberOfEpisodes, timeInterval, category, listOfEpisodes)
        {
        }

        public override string Display()
        {
            return base.Display() + "Podcast";
        }
    }
}
