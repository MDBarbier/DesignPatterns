using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.Database
{
    /// <summary>
    /// Interface for EF Core DbContext file to follow IOC and allow mocking
    /// </summary>
    public interface IApplicationDatabaseContext : IDatabaseContext
    {
        public DbSet<Movie> Movies { get; set; }
    }

}
