using EmirSacOtomotiv.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace EmirSacOtomotiv.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public DbSet<TEntity> Table { get; }
    }
}
