using Azure.Storage.Blobs;
using NotasWorkshop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Services.Services
{
    public class FileManagerLogic : IFileManagerLogic
    {
        private readonly BlobServiceClient _blobServiceClient;
        public FileManagerLogic(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public async Task<string> Upload(BarberWork model)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("images");

            var blobClient = blobContainer.GetBlobClient(model.ImageFile.FileName);

            await blobClient.UploadAsync(model.ImageFile.OpenReadStream());

            return blobClient.Uri.ToString();
        }
        public async Task<byte[]>Read(string fileName)
        {
            var blobContainer = _blobServiceClient.GetBlobContainerClient("images");
            var blobClient = blobContainer.GetBlobClient(fileName);
            var imgDownloaded = await blobClient.DownloadAsync();
            using(MemoryStream ms = new MemoryStream())
            {
                imgDownloaded.Value.Content.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
