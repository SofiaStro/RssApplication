using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Category : Interfaces.INameable
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}
