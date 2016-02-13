using System;

namespace Zenon.MoviesLibrary.Models
{
    public class Library
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string GenresName { get; set; }
        public string DirectorsFirstName { get; set; }
        public string LanguagesName { get; set; }
        public string DirectorsLastName { get; set; }
    }
}
