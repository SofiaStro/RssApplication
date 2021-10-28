using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    public class SerializerException : Exception
    {
        private string xmlFileName;
        public string XmlFileName
        {
            get
            {
                return xmlFileName;
            }
        }
        public SerializerException(string xmlFileName, string message) : base(message)
        {
            this.xmlFileName = xmlFileName;
        }
    }
}
