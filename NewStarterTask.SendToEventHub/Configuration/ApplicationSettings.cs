namespace NewStarterTask.SendToStorage.Configuration
{
    public class ApplicationSettings
    {
        public string SourceEventHubConnectionString { get; set; }
        public string SourceEventHubName { get; set; }
        public string SourceEventHubConsumerGroup { get; set; }
        public string DataLakeConnectionString { get; set; }
        public string DestinationEventHubConnectionString { get; set; }
        public string DestinationEventHubName { get; set; }
    }
}
