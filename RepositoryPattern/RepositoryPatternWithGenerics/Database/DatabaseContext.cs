using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithGenerics.Models;

namespace RepositoryPatternWithGenerics.Database
{
    /// <summary>
    /// EF Core DbContext file, implements an associated interface to follow IOC and allow mocking
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database\\mattsqlitedb1.db");
        }

    }
}
