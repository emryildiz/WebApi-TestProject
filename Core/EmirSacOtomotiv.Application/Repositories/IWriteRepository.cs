using EmirSacOtomotiv.Domain.Common;

namespace EmirSacOtomotiv.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task AddAsync(TEntity entity);

        public Task AddRangeAsync(IEnumerable<TEntity> entities);

        public Task DeleteAsync(int id);

        public Task SaveChangesAsync();
    }
}
