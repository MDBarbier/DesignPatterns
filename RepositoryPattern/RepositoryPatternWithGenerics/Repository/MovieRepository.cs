using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithGenerics.Database;
using RepositoryPatternWithGenerics.Models;
using RepositoryPatternWithGenerics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPatternWithGenerics.Repository
{
    public class MovieRepository : GenericRepository<Movie>
    {
        public MovieRepository(DatabaseContext context) : base(context)
        {

        }        

        
    }
}
