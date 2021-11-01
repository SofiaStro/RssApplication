using Models.Interfaces;

namespace Models.Classes
{
    public class Category : INameable
    {
        public string Name { get; set; }

        public Category() {} // En tom konstuktor för att kunna serialisera/deserialisera objectet. 

        public Category(string name)
        {
            Name = name;
        }
    }
}
