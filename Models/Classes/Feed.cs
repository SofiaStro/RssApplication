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
        public int Episodes { get; set; }
        public int TimeInterval { get; set; }

        public Feed(string name, int episodes, int timeInterval)
        {
            Name = name;
            Episodes = episodes;
            TimeInterval = timeInterval;
        }

        public virtual string Display()
        {
            return "Det här är en: ";
        }

    }
}
