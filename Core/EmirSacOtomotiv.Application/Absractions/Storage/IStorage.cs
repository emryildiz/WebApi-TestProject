using Microsoft.AspNetCore.Http;

namespace EmirSacOtomotiv.Application.Absractions.Storage
{
    public interface IStorage
    {
        Task<List<(string pathOrContainerName, string fileName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        void Delete(string pathOrContainerName);

        List<string> GetFiles(string pathOrContainerName);

        bool HasFile(string pathOrContainerName);
    }
}
