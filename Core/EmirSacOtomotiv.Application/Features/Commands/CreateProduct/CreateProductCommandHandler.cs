using AutoMapper;
using EmirSacOtomotiv.Application.Absractions.Storage;
using EmirSacOtomotiv.Application.Repositories.Products;
using EmirSacOtomotiv.Domain.Common;
using MediatR;

namespace EmirSacOtomotiv.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IProductWriteRepository _repository;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;

        public CreateProductCommandHandler(IProductWriteRepository repository, IMapper mapper, IStorageService storageService)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._storageService = storageService;
        }

        public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string pathOrContainerName, string fileName)> productsPath = await this._storageService.UploadAsync("product-images", request.Images);

            Product product = this._mapper.Map<Product>(request);

            if (productsPath is { Count: > 0 })
            {
                (string pathOrContainerName, string fileName) productPath = productsPath.First();

                product.BigImagePath = Path.Combine(productPath.pathOrContainerName, productPath.fileName);
                product.ImagesPath = new List<string>();

                foreach ((string pathOrContainerName, string fileName) path in productsPath)
                {
                    product.ImagesPath.Add(Path.Combine(path.pathOrContainerName, path.fileName));
                }
            }

            await this._repository.AddAsync(product);
            await this._repository.SaveChangesAsync();
        }
    }
}
