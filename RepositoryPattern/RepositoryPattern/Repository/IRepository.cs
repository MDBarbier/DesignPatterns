using RepositoryPattern.Database;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryPattern.Repository
{
    public interface IRepository<T>
    {
        //T Add(T entity);
        //T Update(T entity);
        T Get(int id);
        IEnumerable<T> All();
        //IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
