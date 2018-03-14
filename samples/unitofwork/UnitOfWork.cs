using System.Threading.Tasks;
using unitofwork.Interfaces;

namespace unitofwork
{
    public class UnitOfWork<TContext> : IUnitOfWork
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        Task<int> IUnitOfWork.Commit()
        {
            throw new System.NotImplementedException();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IObjectInfo
        {
            throw new System.NotImplementedException();
        }
    }
}
