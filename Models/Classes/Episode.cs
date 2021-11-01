namespace Models.Classes

{
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Episode() {}

        public Episode(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
