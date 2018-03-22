using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.Common
{
    public static class DataHelper
    {
        static string MongoConnectionString = "mongodb://imagesdb:IOR9Ix6lqwiVI8pwZCEvZqqbdPU3TODoBs9oIwEmdfElVBiQwi1w35LZt4n7g4mn1CMa3AWcGqKi7cBkMZMXOA==@imagesdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        public static async Task<Image> CreateImageRecord(Image image)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConnectionString));
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("imageProcessor");
            var collection = database.GetCollection<Image>("images");
            await collection.InsertOneAsync(image);

            return image;
        }

        public static async Task<IList<Image>> GetAllImages()
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConnectionString));
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("imageProcessor");
            var collection = database.GetCollection<Image>("images");

            return await collection.Find(FilterDefinition<Image>.Empty).ToListAsync();
        }

        public static async Task<Image> GetImage(string id)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConnectionString));
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("imageProcessor");
            var collection = database.GetCollection<Image>("images");

            var filter = new FilterDefinitionBuilder<Image>().Eq((x) => x._Id, ObjectId.Parse(id));
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public static async Task<bool> UpdateImage(string id, Image updatedImage)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(MongoConnectionString));
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("imageProcessor");
            var collection = database.GetCollection<Image>("images");
            var filter = new FilterDefinitionBuilder<Image>().Eq((x) => x._Id, ObjectId.Parse(id));

            return (await collection.ReplaceOneAsync<Image>((x) => x._Id == ObjectId.Parse(id), updatedImage)).IsAcknowledged;
        }
    }
}
