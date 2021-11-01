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

using Models.Exceptions;

namespace DataAccessLayer
{
    class RssReader
    {
        public async Task<Stream> GetRSSAsync(string url)
        {
            //try
            //{
                return await Task.Run(() =>
                {
                    //Tillåter avläsning av webb-länkar
                    using (var webClient = new WebClient()) 
                    {
                        //Öppnar en läsbar stream från data som är nedladdad från en källa
                        Stream fs = webClient.OpenRead(url);

                        return fs;
                    }
                });
            //}
            //catch (Exception)
            //{
            //    throw new RssReaderException(url, "Url:en gick inte att läsa av");
            //}
        }    
    }
}