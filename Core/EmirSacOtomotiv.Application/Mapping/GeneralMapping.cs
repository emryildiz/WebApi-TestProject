using AutoMapper;
using EmirSacOtomotiv.Application.Features.Commands.CreateProduct;
using EmirSacOtomotiv.Application.Features.Queries.GetAllProducts;
using EmirSacOtomotiv.Domain.Common;

namespace EmirSacOtomotiv.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            this.CreateMap<CreateProductCommandRequest, Product>();
            this.CreateMap<Product, GetAllProductsQueryResponse>();
        }
    }
}
