using Microsoft.Azure.WebJobs;
using SQLPositionFinder;

namespace PositionJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        //public static void ProcessBlobMessage([BlobTrigger("gismaincontainer/posdatarequest{name}")] TextReader message, TextWriter log)
        //{
        //    log.WriteLine(message.ReadToEnd());
        //    log.WriteLine("Test");
        //}
        //public static void CopyBlob([BlobTrigger("gismaincontainer/posdatarequest{name}")] TextReader input,
        //    [Blob("mycontainer/response-{name}")] out string output)
        //{
        //    output = input.ReadToEnd() + "LOL";
        //}

        public static void ModifyQueueMessage([QueueTrigger("messagequeuemainuser")] string queueMessage,
            [Queue("responsequeuemainuser")] out string outputQueueMessage)
        {

            PositionFinder finder = new PositionFinder();
            var result = finder.FindFloor(queueMessage);
            outputQueueMessage = $"{result}";
        }
    }
}
