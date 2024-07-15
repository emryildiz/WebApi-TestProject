using EmirSacOtomotiv.Application.Repositories;
using EmirSacOtomotiv.Domain.Common;
using EmirSacOtomotiv.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmirSacOtomotiv.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        public DbSet<TEntity> Table { get; }

        public ReadRepository(EmirSacOtomotivDbContext context)
        {
            this.Table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.Table.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.Table.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
