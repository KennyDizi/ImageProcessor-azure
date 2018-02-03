using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace ImageProcessor.Api
{
    public static class UploadImage
    {
        static string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=imagestore12345;AccountKey=cWGsKObRVc8+jk6657mYfg3Xwi2XMANIhdGLoWP5XYy8DM30JOlf3AvQnm+sa0X4AA9OvaR19Bcj2m/TTvTwSA==;EndpointSuffix=core.windows.net";
        static string MongoConnectionString = "mongodb://imagesdb:IOR9Ix6lqwiVI8pwZCEvZqqbdPU3TODoBs9oIwEmdfElVBiQwi1w35LZt4n7g4mn1CMa3AWcGqKi7cBkMZMXOA==@imagesdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        [FunctionName("UploadImage")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "upload")]HttpRequestMessage req, TraceWriter log)
        {
            var provider = new MultipartMemoryStreamProvider();
            await req.Content.ReadAsMultipartAsync(provider);
            var file = provider.Contents.First();
            var fileInfo = file.Headers.ContentDisposition;
            var stream = await file.ReadAsByteArrayAsync();

            var newImage = new Image()
            {
                FileName = fileInfo.FileName,
                Size = stream.LongLength
            };

            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConnectionString));
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("imageProcessor");
            var collection = database.GetCollection<Image>("images");
            await collection.InsertOneAsync(newImage);

            var imageName = newImage.Id.ToString();
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("images");

            var blob = container.GetBlockBlobReference(imageName);
            await blob.UploadFromByteArrayAsync(stream, 0, stream.Length);
            return new HttpResponseMessage(HttpStatusCode.Created) { Content = new StringContent(imageName) };
        }
    }
}
