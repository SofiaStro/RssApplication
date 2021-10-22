using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Bus
    {
        public void KallaMetod()
        {
            SerializerForXml objekt = new SerializerForXml();
           objekt.GetFeed();
        }
    }
}
