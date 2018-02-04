using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.Common
{
    public static class StorageHelper
    {
        static string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=imagestore12345;AccountKey=cWGsKObRVc8+jk6657mYfg3Xwi2XMANIhdGLoWP5XYy8DM30JOlf3AvQnm+sa0X4AA9OvaR19Bcj2m/TTvTwSA==;EndpointSuffix=core.windows.net";

        public static async Task<bool> SaveToBlobStorage(string blobName, byte[] data)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("images");

            var blob = container.GetBlockBlobReference(blobName);
            await blob.UploadFromByteArrayAsync(data, 0, data.Length);

            return true;
        }

        public static async Task<byte[]> GetImageData(string imageName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("images");

            var blob = container.GetBlockBlobReference(imageName);
            if (blob == null)
                throw new Exception("Not Found");

            using (var stream = await blob.OpenReadAsync())
            {
                byte[] data = new byte[stream.Length];
                using (var memStream = new MemoryStream())
                {
                    memStream.Write(data, 0, (int)stream.Length);
                    return memStream.ToArray();
                }
            }
        }
    }
}
