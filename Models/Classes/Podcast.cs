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

        public Podcast(string url, string name, int numberOfEpisodes, int timeInterval, string category, 
            List<Episode> listOfEpisodes, string fileName) :
               base(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName)
        {
        }

        public override string Display()
        {
            return base.Display() + "Podcast";
        }
    }
}
