using System;

namespace Zenon.MoviesLibrary.API.Models
{
    public class MovieDbModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int LanguageId { get; set; }

        public Movie GetMovieCore()
        {
            return new Movie
            {
                MovieId = MovieId,
                Title = Title,
                ReleaseDate = ReleaseDate,
                Description = Description
            };
        }
    }
}
