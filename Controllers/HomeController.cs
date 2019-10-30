using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Data;
using WebApplication3.Models.MovieViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoviesContext _context;

        public HomeController(MoviesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string titleString, string genreString, string actorString)
        {
            var viewModel = new MoviesIndexData();

            viewModel.Movies = await _context.Movies
                .Include(a => a.MovieActors)
                    .ThenInclude(a => a.Actor)
                .AsNoTracking()
                .ToListAsync();

            if (!String.IsNullOrEmpty(titleString))
            {
                viewModel.Movies = viewModel.Movies.Where(m => m.Title.ToLower().Contains(titleString.Trim().ToLower()));
            }
            else if (!String.IsNullOrEmpty(genreString))
            {
                viewModel.Movies = viewModel.Movies.Where(m => m.Genre.ToLower().Contains(genreString.Trim().ToLower()));
            }
            else if (!String.IsNullOrEmpty(actorString))
            {
                viewModel.Movies = viewModel.Movies.SelectMany(m => m.MovieActors
                .Where(ma => ma.Actor.FirstName.ToLower().Contains(actorString.Trim().ToLower()) || 
                             ma.Actor.LastName.ToLower().Contains(actorString.Trim().ToLower()))
                .Select(u => u.Movie));
            }

            return View(viewModel);
        }



        public async Task<IActionResult> Actors()
        {
            var viewModel = new MoviesIndexData();

            viewModel.Actors = await _context.Actors
                .Include(a => a.MovieActors)
                    .ThenInclude(a => a.Movie)
                .AsNoTracking()
                .ToListAsync();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
