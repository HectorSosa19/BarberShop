using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
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
        protected BlobServiceClient blobClient;
        protected BlobClient _client;
        protected BlobContainerClient containerClient;
        public FileManagerLogic()
        {
            blobClient = new BlobServiceClient(StorageAccount.connection);
        }

        public async Task<string> Upload(IFormFile model)
        {
            string fileName = $"{Guid.NewGuid().ToString()}-{model.FileName}";
            containerClient = blobClient.GetBlobContainerClient("images");
            _client = containerClient.GetBlobClient(fileName);
            using (var fileStream = await _client.OpenWriteAsync(true, new BlobOpenWriteOptions()))
            {
                await model.CopyToAsync(fileStream);
                fileStream.Close();
            }
            return _client.Uri.ToString();
        }
    }
}
