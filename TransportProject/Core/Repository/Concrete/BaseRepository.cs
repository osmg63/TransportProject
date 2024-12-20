using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TransportProject.Core.Repository.Abstract;
using TransportProject.Data.DbContexts;

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

        public async Task<TEntity> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<Boolean> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            int result= await _context.SaveChangesAsync();
            return result > 0;
        
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return  await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? await _context.Set<TEntity>().ToListAsync() :
             await  _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }


}
