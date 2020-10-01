using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryPatternWithGenerics.Models;
using RepositoryPatternWithGenerics.UnitOfWork;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace RepositoryPatternWithGenerics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        //The unit of work gives a single access point to our various repositories
        private readonly IUnitOfWork unitOfWork;
                                
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            try
            {
                //Get all movies via the repository - note this controller knows nothing about sqlite, or anything in the database folder
                var data = unitOfWork.MovieRepository.All();
                var json = JsonSerializer.Serialize(data);

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

        public IActionResult Add(string json)
        {
            var movieToAdd = JsonSerializer.Deserialize<Movie>(json);

            var added = unitOfWork.MovieRepository.Add(movieToAdd);
            unitOfWork.MovieRepository.SaveChanges();

            var addedMovie = unitOfWork.MovieRepository.Find(movie => movie.Title == movieToAdd.Title).FirstOrDefault();

            if (addedMovie == null)
            {
                ViewBag.json = "Failed to add movie";
            }
            else
            {
                ViewBag.json = JsonSerializer.Serialize<Movie>(addedMovie);
            }

            
            return View();
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
