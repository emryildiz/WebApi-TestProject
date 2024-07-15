using MediatR;
using Microsoft.AspNetCore.Http;

namespace EmirSacOtomotiv.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductBigImageCommandRequest : IRequest
    {
        public string Name { get; set; }

        public IFormFile BigImage { get; set; }
    }
}
