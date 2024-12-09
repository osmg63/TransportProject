using System.Linq.Expressions;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data;

namespace TransportProject.Core.Repository.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly TransportDbContext _context;

        public BaseRepository(TransportDbContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Boolean Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            int result=_context.SaveChanges();
            return result > 0;
        
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _context.Set<TEntity>().ToList() :
               _context.Set<TEntity>().Where(filter).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }


}
