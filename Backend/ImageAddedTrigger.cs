using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessor.Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ProjectOxford.Vision;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Backend
{
    public static class ImageAddedTrigger
    {
        static string VisionApiUrl = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0";
        static string VisionApiKey = "8e91cc6859b6419e913383a0a2da84a0";

        [FunctionName("ImageAddedTrigger")]
        public static async Task Run([BlobTrigger("images/{name}", Connection = "StorageConnectionString")]Stream imageStream, string name, TraceWriter log)
        {
            log.Info(string.Format("Target Id: {0}", name));
            IVisionServiceClient client = new VisionServiceClient(VisionApiKey, VisionApiUrl);
            var features = new VisualFeature[] {
                VisualFeature.Adult,
                VisualFeature.Categories,
                VisualFeature.Color,
                VisualFeature.ImageType,
                VisualFeature.Tags
            };

            var result = await client.AnalyzeImageAsync(imageStream, features);
            log.Info("Analysis Complete");

            var image = await DataHelper.GetImage(name);
            log.Info(string.Format("Image is null: {0}", image == null));
            log.Info(string.Format("Image Id: {0}", image.Id));

            if (image != null)
            {
                image.Adult = new AdultData(result.Adult.AdultScore, result.Adult.IsAdultContent, result.Adult.IsRacyContent, result.Adult.RacyScore);
                log.Info(string.Format("Adult Score: {0}", image.Adult.AdultScore));

                image.Categories = result.Categories.Select((x) => new CategoryData(x.Name, x.Score)).ToList();
                image.Color = new ColorData(result.Color.AccentColor, result.Color.DominantColorBackground, result.Color.DominantColorForeground, result.Color.IsBWImg);
                image.TypeData = new TypeData(result.ImageType.ClipArtType.ToString(), result.ImageType.LineDrawingType.ToString());
                image.TagData = result.Tags.Select((x) => new TagData(x.Confidence, x.Name)).ToList();

                if (!(await DataHelper.UpdateImage(image.Id, image)))
                {
                    log.Error(string.Format("Failed to Analyze Image: {0}", name));
                }
                else
                {
                    log.Info("Update Complete");
                }
            }
        }
    }
}
