using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Models.Classes;
using System.Timers;

namespace DataAccessLayer
{
    class RssReader
    {
        public async Task<Stream> GetRSSAsync(string url)
        {
            return await Task.Run(() =>
            {
                using (var webClient = new WebClient()) //Tillåter avläsning av webb-länkar
                {
                    Stream fs = webClient.OpenRead(url); //Öppnar en läsbar stream från data som är nedladdad från en källa

                    return fs;
                }
            });
        }
    }

    
}
