using MediatR;

namespace EmirSacOtomotiv.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<List<GetAllProductsQueryResponse>> { }
}
