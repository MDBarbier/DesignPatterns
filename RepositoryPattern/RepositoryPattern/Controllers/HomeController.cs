using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryPattern.Models;
using RepositoryPattern.ServiceLayer;
using System.Diagnostics;
using System.Text.Json;

namespace RepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Holds our repository implementation
        private readonly IMovieRepository movieRepository;

        //Repository is injected at construction time
        public HomeController(ILogger<HomeController> logger, IMovieRepository movieAccessMethods)
        {
            _logger = logger;
            movieRepository = movieAccessMethods;
        }

        public IActionResult Index()
        {
            try
            {
                //Get all movies via the repository - note this controller knows nothing about sqlite, or anything in the database folder
                var data = movieRepository.GetAllMovies();
                var json = JsonSerializer.Serialize(data.Values);

                //This is bad practice, in reality we would use a viewmodel,
                //but this is a demo of repository pattern so just go with it
                ViewBag.json = json;
                return View();
            }
            catch (System.Exception ex)
            {
                ViewBag.json = ex.Message;
                return View();
            }
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
