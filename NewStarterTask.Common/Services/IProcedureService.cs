namespace NewStarterTask.Core.Services
{
    public interface IProcedureService
    {
        Task ResetDataAsync();
        Task SeedDataAsync();
    }
}
