using EmirSacOtomotiv.Application.Features.Commands.CreateProduct;
using EmirSacOtomotiv.Application.Features.Commands.UpdateProduct;
using EmirSacOtomotiv.Application.Features.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmirSacOtomotiv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            List<GetAllProductsQueryResponse> response = await this._mediator.Send(new GetAllProductsQueryRequest());

            return this.Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBigImage(UpdateProductBigImageCommandRequest request)
        {
            await this._mediator.Send(request);

            return this.Ok();
        }
    }
}
