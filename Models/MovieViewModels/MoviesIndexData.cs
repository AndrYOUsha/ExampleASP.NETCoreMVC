using System.Collections.Generic;

namespace WebApplication3.Models.MovieViewModels
{
    public class MoviesIndexData
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}
