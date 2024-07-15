using EmirSacOtomotiv.Domain.Common;

namespace EmirSacOtomotiv.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public IQueryable<TEntity> GetAll();

        public Task<TEntity> GetByIdAsync(int id);
    }
}
