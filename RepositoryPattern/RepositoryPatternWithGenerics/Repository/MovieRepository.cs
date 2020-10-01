using RepositoryPatternWithGenerics.Database;
using RepositoryPatternWithGenerics.Models;

namespace RepositoryPatternWithGenerics.Repository
{
    public class MovieRepository : GenericRepository<Movie>
    {
        public MovieRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
