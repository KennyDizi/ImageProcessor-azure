using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ImageProcessor.Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace ImageProcessor.Api
{
    public static class UploadImage
    {
        [FunctionName("UploadImage")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "upload")]HttpRequestMessage req, TraceWriter log)
        {
            var provider = new MultipartMemoryStreamProvider();
            await req.Content.ReadAsMultipartAsync(provider);
            var file = provider.Contents.First();
            var fileInfo = file.Headers.ContentDisposition;
            var fileData = await file.ReadAsByteArrayAsync();

            var newImage = new Image()
            {
                FileName = fileInfo.FileName,
                Size = fileData.LongLength,
                Status = ImageStatus.Processing
            };

            var image = await DataHelper.CreateImageRecord(newImage);
            if (!(await StorageHelper.SaveToBlobStorage(image.Id, fileData)))
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            
            return new HttpResponseMessage(HttpStatusCode.Created) { Content = new StringContent(JsonConvert.SerializeObject(image)) };
        }
    }
}
