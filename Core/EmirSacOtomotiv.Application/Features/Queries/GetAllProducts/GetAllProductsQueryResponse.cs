namespace EmirSacOtomotiv.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BigImagePath { get; set; }

        public List<string> ImagesPath { get; set; }
    }
}
