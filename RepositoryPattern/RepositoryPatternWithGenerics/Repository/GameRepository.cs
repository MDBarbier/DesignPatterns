using RepositoryPatternWithGenerics.Database;
using RepositoryPatternWithGenerics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryPatternWithGenerics.Repository
{
    public class GameRepository : GenericRepository<Game>
    {
        public GameRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
