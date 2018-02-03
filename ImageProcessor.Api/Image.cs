using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.Api
{
    public class Image
    {
        [BsonId, JsonIgnore]
        public ObjectId _Id { get; set; }

        [JsonProperty("id")]
        public string Id
        {
            get { return _Id.ToString(); }
            set
            {
                ObjectId parsedValue;
                if (ObjectId.TryParse(value, out parsedValue))
                    _Id = parsedValue;
                else
                    _Id = ObjectId.Empty;
            }
        }

        [JsonProperty("name")]
        public string FileName { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
