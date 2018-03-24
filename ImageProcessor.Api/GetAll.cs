using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ImageProcessor.Common;
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
        public static async Task<IList<Image>> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "all")]HttpRequestMessage req, TraceWriter log)
        {
            return (await DataHelper.GetAllImages()).OrderByDescending(x => x.AddedOn).ToList();
        }
    }
}
