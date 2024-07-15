namespace EmirSacOtomotiv.Domain.Common
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string BigImagePath { get; set; }

        public List<string> ImagesPath { get; set; }
    }
}
