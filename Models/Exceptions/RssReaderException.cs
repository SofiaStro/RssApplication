using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class RssReaderException : Exception
    {

        //private string url;
        public string Url
        {
            get;
            //{
            //    return url;
            //}
        }
        public RssReaderException(string url, string message) : base(message)
        {
            Url = url;
        }
    }
}
