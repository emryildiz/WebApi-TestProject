using EmirSacOtomotiv.Application.Repositories.Products;
using EmirSacOtomotiv.Domain.Common;
using EmirSacOtomotiv.Persistence.Context;

namespace EmirSacOtomotiv.Persistence.Repositories.Products
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(EmirSacOtomotivDbContext context) : base(context) { }
    }
}
