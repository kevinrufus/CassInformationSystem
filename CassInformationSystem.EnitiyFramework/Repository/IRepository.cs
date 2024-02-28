using System.Linq.Expressions;

namespace CassInformationSystem.EnitiyFramework.Repository
{
    //This repository contains only essential functions, but it can be extended to a wide range of functions
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> Get(long id);
        Task Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> ExecuteStoredProc(int shipperId);
    }
}
