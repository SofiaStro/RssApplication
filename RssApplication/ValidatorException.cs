using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssApplication
{
    class ValidatorException : Exception
    {
        public ValidatorException(string message) : base(message) 
        {
        }

    }
}
