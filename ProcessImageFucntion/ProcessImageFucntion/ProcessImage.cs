using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace ProcessImageFucntion
{
    public static class ProcessImage
    {
        [FunctionName("ProcessImage")]
        public static void Run([BlobTrigger("imageprocessorimagestore/images/{name}")]Stream myBlob, string name, TraceWriter log)
        {
            log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
