using System.Linq.Expressions;

namespace TransportProject.Core.Repository.Abstract
{
    public interface IBaseRepository<TEntity>
       where TEntity : class, new()
    {
        TEntity Add(TEntity entity);
        Boolean Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        void SaveChanges();
    }
}
