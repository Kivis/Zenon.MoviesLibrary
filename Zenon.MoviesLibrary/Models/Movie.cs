using System;

namespace Zenon.MoviesLibrary.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public Director Director { get; set; }
        public Language Language { get; set; }
    }
}
