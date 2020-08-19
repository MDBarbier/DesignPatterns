using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Database;
using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern.ServiceLayer
{
    public class MovieRepository : IMovieRepository
    {
        public IApplicationDatabaseContext DbContext { get; }        

        public MovieRepository(IApplicationDatabaseContext databaseContext)
        {
            DbContext = databaseContext;                
        }
        
        public Movie GetMovieById(int movieId)
        {
            return DbContext.Movies.Where(a => a._id == movieId).FirstOrDefault();
        }

        /// <summary>
        /// Get all customer objects
        /// </summary>
        /// <returns>A dictionary, the key being the customerId and the value the customer object</returns>
        public Dictionary<int, Movie> GetAllMovies()
        {
            return DbContext.Movies.AsNoTracking().ToDictionary(a => a._id, a => a);
        }
    }
}
