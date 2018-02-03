using ImageProcessor.Common;
using Newtonsoft.Json;
using System;

namespace ImageProcessor.Api
{
    public class ImageResponse : Image
    {
        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get { return string.Format("http://{0}/api/image/{1}", Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME"), Id); }
        }
    }
}
