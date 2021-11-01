namespace Models.Classes

{
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Episode() { } // En tom konstuktor för att kunna serialisera/deserialisera objectet. 

        public Episode(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
