using EmirSacOtomotiv.Application.Absractions.Storage;
using Microsoft.AspNetCore.Http;

namespace EmirSacOtomotiv.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public string StorageName => this._storage.GetType().Name;

        public StorageService(IStorage storage)
        {
            this._storage = storage;
        }

        public async Task<List<(string pathOrContainerName, string fileName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            return await this._storage.UploadAsync(pathOrContainerName, files);
        }

        public void Delete(string pathOrContainerName)
        {
            this._storage.Delete(pathOrContainerName);
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            return this._storage.GetFiles(pathOrContainerName);
        }

        public bool HasFile(string pathOrContainerName)
        {
            return this._storage.HasFile(pathOrContainerName);
        }
    }
}
