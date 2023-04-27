using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Services.Delegate
{
    public class ProcedureService: IProcedureService
    {
        private readonly IApiService _apiService;
        private const string _capabilityBaseUrl = "api/procedures";

        public ProcedureService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task ResetDataAsync()
        {
            await _apiService.SendAsync($"{_capabilityBaseUrl}/reset", HttpMethod.Get);
        }

        public async Task SeedDataAsync()
        {
            await _apiService.SendAsync($"{_capabilityBaseUrl}/seed", HttpMethod.Get);
        }
    }
}
