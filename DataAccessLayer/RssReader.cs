using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    class RssReader
    {
        public async Task<Stream> GetRSSAsync(string url)
        {
            Stream fs = null;
            try
            {
                await Task.Run(() =>
                {
                    //Tillåter avläsning av webb-länkar
                    using (var webClient = new WebClient()) 
                    {
                        //Öppnar en läsbar stream från data som är nedladdad från en källa
                         fs = webClient.OpenRead(url);
                        //return fs;

                    }
                });
            }
            catch (Exception)
            {
            }
            return fs;
        }
    }
}