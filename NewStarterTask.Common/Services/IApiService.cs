namespace NewStarterTask.Core.Services
{
    public interface IApiService
    {
        Task<HttpResponseMessage> SendAsync(string urlSuffix, HttpMethod method, object body = null);
    }
}
