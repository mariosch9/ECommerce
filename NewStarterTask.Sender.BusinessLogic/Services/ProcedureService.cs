using NewStarterTask.Core.Repositories;
using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Services
{
    public class ProcedureService: IProcedureService
    {
        private readonly IProcedureRepository _procedureRepository;

        public ProcedureService(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public async Task ResetDataAsync()
        {
            await _procedureRepository.ResetDataAsync();
        }

        public async Task SeedDataAsync()
        {
            await _procedureRepository.SeedDataAsync();
        }
    }
}
