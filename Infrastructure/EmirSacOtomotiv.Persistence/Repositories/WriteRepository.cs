using EmirSacOtomotiv.Application.Repositories;
using EmirSacOtomotiv.Domain.Common;
using EmirSacOtomotiv.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmirSacOtomotiv.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly EmirSacOtomotivDbContext _dbContext;

        public DbSet<TEntity> Table { get; }

        public WriteRepository(EmirSacOtomotivDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.Table = this._dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await this.Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.Table.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entity = await this.Table.FirstOrDefaultAsync(t => t.Id == id);

            if (entity is null) { throw new Exception("Entity yok"); }

            this.Table.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }
    }
}
