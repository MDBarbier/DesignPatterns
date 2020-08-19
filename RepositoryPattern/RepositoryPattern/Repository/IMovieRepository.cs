using RepositoryPattern.Database;
using RepositoryPattern.Models;
using System.Collections.Generic;

namespace RepositoryPattern.ServiceLayer
{
    public interface IMovieRepository
    {
        public abstract IApplicationDatabaseContext DbContext { get; }
        
        public abstract Movie GetMovieById(int movieId);
        
        public abstract Dictionary<int, Movie> GetAllMovies();
    }
}
