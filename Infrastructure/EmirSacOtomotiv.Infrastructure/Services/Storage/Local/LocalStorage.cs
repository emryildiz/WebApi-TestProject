using EmirSacOtomotiv.Application.Absractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EmirSacOtomotiv.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<(string pathOrContainerName, string fileName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            List<(string pathOrContainerName, string fileName)> filePaths = new();

            //webrootpath wwwroot yoluna götürür.
            //wwwroot/resource/product-images
            string uploadPath = Path.Combine(this._webHostEnvironment.WebRootPath, pathOrContainerName);

            if (Directory.Exists(uploadPath) == false)
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (IFormFile file in files)
            {
                string newFileName = await this.FileRenameAsync(file.FileName);

                string fullPath = Path.Combine(uploadPath, newFileName);

                bool result = await this.CopyFileAsync(fullPath, file);

                if (result == false)
                {
                    //Todo throw exception
                    return null;
                }

                filePaths.Add(new ValueTuple<string, string>(pathOrContainerName, newFileName));
            }

            return filePaths;
        }

        public void Delete(string pathOrContainerName) => File.Delete(pathOrContainerName);

        public List<string> GetFiles(string pathOrContainerName)
        {
            DirectoryInfo dir = new(pathOrContainerName);

            return dir.GetFiles().Select(x => x.Name).ToList();
        }

        public bool HasFile(string pathOrContainerName) => File.Exists(pathOrContainerName);

        private async Task<string> FileRenameAsync(string fileName)
        {
            // TODO File rename
            await Task.Run(() => Thread.Sleep(1));

            return fileName;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 1024 * 1024, useAsync: false);

                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return true;
            }
            catch
            {
                //TODO log!
                throw;
            }
        }
    }
}
