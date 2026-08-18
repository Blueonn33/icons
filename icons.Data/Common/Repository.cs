using Microsoft.EntityFrameworkCore;

namespace icons.Data.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _set;

        public Repository(ApplicationDbContext context, DbSet<TEntity> set)
        {
            _context = context;
            _set = set;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _set.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _set.FindAsync(id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity of type {typeof(TEntity).Name} with Id {id} was not found.");
            }

            return entity;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }
    }
}
