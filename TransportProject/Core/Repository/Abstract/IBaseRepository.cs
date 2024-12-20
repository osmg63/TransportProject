using System.Linq.Expressions;

namespace TransportProject.Core.Repository.Abstract
{
    public interface IBaseRepository<TEntity>
       where TEntity : class, new()
    {
        Task<TEntity> Add(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task SaveChangesAsync();
    }
}
