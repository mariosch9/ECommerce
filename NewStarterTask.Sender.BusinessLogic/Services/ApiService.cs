using System.Text;
using Microsoft.Extensions.Configuration;
using NewStarterTask.Core.Services;
using Newtonsoft.Json;

namespace NewStarterTask.BusinessLogic.Services
{
    public class ApiService: IApiService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public ApiService(IConfiguration configuration)
        {
            _client = new HttpClient();
            _baseUrl = configuration["apiUrl"].ToString();
        }

        public async Task<HttpResponseMessage> SendAsync(string urlSuffix, HttpMethod method, object body = null)
        {
            var uri = new Uri($"{_baseUrl}{urlSuffix}");
            if ((method == HttpMethod.Get && body != null) || method == HttpMethod.Delete)
            {
                uri = new Uri($"{_baseUrl}{urlSuffix}/{body}");
            }

            using (var httpRequest = new HttpRequestMessage(method, uri))
            {
                try
                {
                    if (body != null && method != HttpMethod.Get)
                    {
                        var content = JsonConvert.SerializeObject(body);
                        httpRequest.Content = new StringContent(content, Encoding.UTF8, "application/json");
                    }

                    var response = await _client.SendAsync(httpRequest);

                    if (!response.IsSuccessStatusCode)
                    {
                        var respStr = await response.Content.ReadAsStringAsync();
                        var errorMessage = new StringBuilder($"Http Response: {response.StatusCode}");
                        if (string.IsNullOrEmpty(respStr))
                        {
                            errorMessage.Append($" with Error: {respStr}");
                        }

                        response.ReasonPhrase = errorMessage.ToString();
                    }

                    return response;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
