using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using unitofwork.Interfaces;

namespace unitofwork
{
    public class Repository<TEntity> where TEntity : class, IObjectInfo, IRepository<TEntity>
    {
        protected readonly DbContext _currentContext;
        protected readonly IDbSet<TEntity> _currentSet;

        public Repository(DbContext currentContext)
        {
            if (currentContext != null)
                _currentContext = currentContext;
            _currentSet = _currentContext.Set<TEntity>();
        }

        public void Add(TEntity value)
        {
            _currentSet.Add(value);
        }

        public int Count()
        {
            return _currentSet.Count();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeProps = "")
        {
            var query = _currentSet.Where(predicate);
            if (!string.IsNullOrEmpty(includeProps))
            {
                var properties = includeProps.Split(new char[] { ';' });
                foreach (var property in properties)
                    query = query.Include(property);
            }
            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _currentSet.AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            return _currentSet.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(TEntity value)
        {
            _currentSet.Remove(value);
        }
    }
}
