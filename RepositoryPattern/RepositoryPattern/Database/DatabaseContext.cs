using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Database
{
    /// <summary>
    /// EF Core DbContext file, implements an associated interface to follow IOC and allow mocking
    /// </summary>
    public class DatabaseContext : DbContext, IApplicationDatabaseContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbContext Instance => this;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database\\mattsqlitedb1.db");
        }

    }
}
