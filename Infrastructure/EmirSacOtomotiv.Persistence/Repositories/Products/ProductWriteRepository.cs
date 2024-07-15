using EmirSacOtomotiv.Application.Repositories.Products;
using EmirSacOtomotiv.Domain.Common;
using EmirSacOtomotiv.Persistence.Context;

namespace EmirSacOtomotiv.Persistence.Repositories.Products
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(EmirSacOtomotivDbContext dbContext) : base(dbContext) { }
    }
}
