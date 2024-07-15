namespace EmirSacOtomotiv.Application.Absractions.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
