using RepositoryPatternWithGenerics.Database;
using RepositoryPatternWithGenerics.Models;
using RepositoryPatternWithGenerics.Repository;

namespace RepositoryPatternWithGenerics.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //The unit of work has it's own Database context which it uses for all operations
        //This same context is injected into all of the repositories so they are all using the same one
        private DatabaseContext DatabaseContext;

        public UnitOfWork(DatabaseContext context)
        {
            this.DatabaseContext = context;
        }

        //Each repository is lazy loaded
        private IRepository<Movie> movieRepository;
        public IRepository<Movie> MovieRepository
        {
            get
            {
                if (movieRepository == null)
                {
                    //We instantiate the repository manually, and it in turn instantiates the generic repository
                    //Both use the same DatabaseContext we pass in
                    movieRepository = new MovieRepository(DatabaseContext);
                }

                return movieRepository;
            }
        }

        private IRepository<Game> gameRepository;
        public IRepository<Game> GameRepository
        {
            get
            {
                if (movieRepository == null)
                {
                    gameRepository = new GameRepository(DatabaseContext);
                }

                return gameRepository;
            }
        }

        public void SaveChanges()
        {
            DatabaseContext.SaveChanges();
        }
    }
}
