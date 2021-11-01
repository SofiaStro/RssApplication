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
            Stream stream = null;
            try
            {
                await Task.Run(() =>
                {
                    //Tillåter avläsning av webb-länkar
                    using (var webClient = new WebClient()) 
                    {
                        //Öppnar en läsbar stream från data som är nedladdad från en källa
                         stream = webClient.OpenRead(url);
                    }
                });
            }
            catch (Exception) {}
            return stream;
        }
    }
}