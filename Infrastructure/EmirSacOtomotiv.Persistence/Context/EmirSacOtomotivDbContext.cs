using EmirSacOtomotiv.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace EmirSacOtomotiv.Persistence.Context
{
    public class EmirSacOtomotivDbContext : DbContext
    {
        public EmirSacOtomotivDbContext(DbContextOptions<EmirSacOtomotivDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
