using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class News : Feed
    {
        public News(string name, int episodes, int timeInterval) :  
                base(name, episodes, timeInterval)
        {
        }

        public override string Display()
        {
            return base.Display() + "Nyhet";
        }
    }
}
