using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenon.MoviesLibrary.Models
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
            return new Movie()
            {
                MovieId = this.MovieId,
                Title = this.Title,
                ReleaseDate = this.ReleaseDate,
                Description = this.Description
            };
        }
    }
}
