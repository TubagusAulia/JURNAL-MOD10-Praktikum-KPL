namespace modul10_103022300141.Models
{
    public class Movie
    {
        public string tittle { get; set; }
        public string director { get; set; }

        public List<string> stars { get; set; }

        public string description { get; set; }

        public Movie(string tittle, string director, List<string> stars, string description)
        {
            this.tittle = tittle;
            this.director = director;
            this.stars = stars;
            this.description = description;
        }
    }
}
