using AutoMapper;
using EmirSacOtomotiv.Application.Repositories.Products;
using EmirSacOtomotiv.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmirSacOtomotiv.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            this._productReadRepository = productReadRepository;
            this._mapper = mapper;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            List<Product> products = await this._productReadRepository.GetAll().ToListAsync(cancellationToken);

            List<GetAllProductsQueryResponse> response = this._mapper.Map<List<GetAllProductsQueryResponse>>(products);

            return response;
        }
    }
}
