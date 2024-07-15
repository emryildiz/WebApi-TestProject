using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmirSacOtomotiv.Application.Absractions.Storage;
using EmirSacOtomotiv.Application.Repositories.Products;
using EmirSacOtomotiv.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;

namespace EmirSacOtomotiv.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductBigImageCommandHandler : IRequestHandler<UpdateProductBigImageCommandRequest>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IStorageService _storageService;

        public UpdateProductBigImageCommandHandler(IProductWriteRepository productWriteRepository, IStorageService storageService)
        {
            this._productWriteRepository = productWriteRepository;
            this._storageService = storageService;
        }

        public async Task Handle(UpdateProductBigImageCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await this._productWriteRepository.Table.FirstOrDefaultAsync(x => x.Name.Equals(request.Name), cancellationToken: cancellationToken);

            if (product is null) { throw new Exception("Product not found"); }

            this._storageService.Delete(product.BigImagePath);

            List<(string pathOrContainerName, string fileName)> path = await this._storageService.UploadAsync("product-images", new FormFileCollection { request.BigImage });

            if (path.Count > 0) { product.BigImagePath = Path.Combine(path[0].pathOrContainerName, path[0].fileName); }
        }
    }
}
