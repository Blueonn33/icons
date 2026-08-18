namespace icons.Data.Common
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task SaveAsync();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
