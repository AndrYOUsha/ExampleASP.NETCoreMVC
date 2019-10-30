using System;
using System.Linq;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class DbInitializer
    {
        public static void Initialize(MoviesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Actors.Any())
            {
                return;
            }

            var actors = new Actor[]
            {
                new Actor{ActorId = 1, FirstName = "Джейсон", LastName = "Стейтем" },
                new Actor{ActorId = 2, FirstName = "Винни", LastName = "Джонс"},
                new Actor{ActorId = 3, FirstName = "Стинг", LastName = ""},
                new Actor{ActorId = 4, FirstName = "Эми", LastName = "Смарт"},
                new Actor{ActorId = 5, FirstName = "Рено", LastName = "Уилсон"},
                new Actor{ActorId = 6, FirstName = "Джейсон", LastName = "Флеминг"},
                new Actor{ActorId = 7, FirstName = "Дэвид", LastName = "Келли"}
            };
            foreach(var a in actors)
            {
                context.Actors.Add(a);
            }

            var movies = new Movie[]
            {
                new Movie{MovieId = 1, Title = "Карты, деньги, 2 ствола", Genre = "Криминал", ReleaseDate = DateTime.Parse("01-01-1998")},
                new Movie{MovieId = 2, Title = "Адреналин", Genre = "боевик", ReleaseDate = DateTime.Parse("01-01-2006")},
                new Movie{MovieId = 3, Title = "Костолом", Genre = "драма", ReleaseDate = DateTime.Parse("01-01-2001")}
            };
            foreach(var m in movies)
            {
                context.Movies.Add(m);
            }

            var movieActors = new MovieActor[]
            {
                new MovieActor{ActorId = 1, MovieId = 1},
                new MovieActor{ActorId = 1, MovieId = 2},
                new MovieActor{ActorId = 1, MovieId = 3},
                new MovieActor{ActorId = 2, MovieId = 1},
                new MovieActor{ActorId = 2, MovieId = 3},
                new MovieActor{ActorId = 3, MovieId = 1},
                new MovieActor{ActorId = 4, MovieId = 2},
                new MovieActor{ActorId = 5, MovieId = 2},
                new MovieActor{ActorId = 6, MovieId = 3},
                new MovieActor{ActorId = 7, MovieId = 3},
            };
            foreach (var ma in movieActors)
            {
                context.MovieActors.Add(ma);
            }
            context.SaveChanges();
        }
    }
}
