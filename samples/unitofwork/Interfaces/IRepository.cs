using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace unitofwork.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IObjectInfo
    {
        void Add(TEntity value);

        void Remove(TEntity value);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeProps = "");

        int Count();
    }
}