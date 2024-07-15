using MediatR;
using Microsoft.AspNetCore.Http;

namespace EmirSacOtomotiv.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFileCollection Images { get; set; }
    }
}
