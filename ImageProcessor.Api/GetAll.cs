using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using MongoDB.Driver;

namespace ImageProcessor.Api
{
    public static class GetAll
    {
        static string MongoConnectionString = "mongodb://imagesdb:IOR9Ix6lqwiVI8pwZCEvZqqbdPU3TODoBs9oIwEmdfElVBiQwi1w35LZt4n7g4mn1CMa3AWcGqKi7cBkMZMXOA==@imagesdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        [FunctionName("GetAll")]
        public static async Task<IList<ImageResponse>> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "all")]HttpRequestMessage req, TraceWriter log)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConnectionString));
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("imageProcessor");
            var collection = database.GetCollection<ImageResponse>("images");
            return await collection.Find(FilterDefinition<ImageResponse>.Empty).ToListAsync();
        }
    }
}
