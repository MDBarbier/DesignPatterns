using RepositoryPatternWithGenerics.Models;
using RepositoryPatternWithGenerics.Repository;

namespace RepositoryPatternWithGenerics.UnitOfWork
{
    /// <summary>
    /// Unit of work pattern helps you when you have multiple repositories
    /// 
    /// Allows grouping of operations on multiple types into a single transaction
    /// 
    /// Saves having to close and recreate the connection for operations with dependant types
    /// 
    /// Gives you a centralised access point making sure requests are synchronised and also reducing the connection to the database
    /// </summary>
    public interface IUnitOfWork
    {
        IRepository<Movie> MovieRepository { get; }
        IRepository<Game> GameRepository { get; }

        void SaveChanges();
    }
}
