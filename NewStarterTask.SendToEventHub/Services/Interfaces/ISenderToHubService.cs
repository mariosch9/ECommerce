using Aquifer.DataPipe.Letters;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewStarterTask.SendToEventHub.Services.Interfaces
{
    public interface ISenderToHubService
    {
        Task UploadMessagesAsync(Queue<Letter<object>> messages, ILogger logger);
    }
}
