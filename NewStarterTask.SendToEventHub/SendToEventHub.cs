using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aquifer.DataPipe.Letters;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using NewStarterTask.SendToEventHub.Services.Interfaces;
using Newtonsoft.Json;

namespace NewStarterTask.SendToEventHub
{
    public class SendToEventHub
    {
        private readonly ISenderToHubService _senderToHubService;

        public SendToEventHub(ISenderToHubService senderToHubService)
        {
            _senderToHubService = senderToHubService;
        }

        [FunctionName("SendToEventHub")]
        public async Task Run(
            [EventHubTrigger("%SourceEventHubName%", Connection = @"SourceEventHubConnectionString", ConsumerGroup = "%SourceEventHubConsumerGroup%")] string[] events,
            ILogger log)
        {
            var blobOutResults = new Queue<Letter<object>>();
            var exceptions = new List<Exception>();
            //EventData
            foreach (string eventData in events)
            {
                try
                {
                    var messageLetter = JsonConvert.DeserializeObject<Letter<object>>(eventData);

                    blobOutResults.Enqueue(messageLetter);
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            if (blobOutResults.Count > 0)
            {
                await _senderToHubService.UploadMessagesAsync(blobOutResults, log);
            }

            if (exceptions != null && exceptions.Count > 0)
            {
                if (log != null)
                    log.LogError(JsonConvert.SerializeObject(exceptions));
            }

        }
    }
}