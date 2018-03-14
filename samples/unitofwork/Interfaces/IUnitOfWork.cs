using System;
using System.Threading.Tasks;

namespace unitofwork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IObjectInfo;

        Task<int> Commit();
    }
}
