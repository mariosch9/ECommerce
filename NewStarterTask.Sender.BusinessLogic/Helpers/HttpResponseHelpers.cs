using Newtonsoft.Json;

namespace NewStarterTask.BusinessLogic.Helpers
{
    public static class HttpResponseHelpers
    {
        public static async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(
                await response.Content.ReadAsStringAsync());
        }
    }
}
