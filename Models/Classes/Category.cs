using Models.Interfaces;

namespace Models.Classes
{
    public class Category : INameable
    {
        public string Name { get; set; }

        public Category() {}

        public Category(string name)
        {
            Name = name;
        }
    }
}
