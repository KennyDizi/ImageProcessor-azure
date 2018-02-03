using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ImageProcessor.Common
{
    public class Image
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        [JsonProperty("id")]
        public string Id
        {
            get { return _Id.ToString(); }
            set { _Id = ObjectId.Parse(value); }
        }

        [JsonProperty("name")]
        public string FileName { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
