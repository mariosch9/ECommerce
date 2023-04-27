namespace NewStarterTask.Core.Repositories
{
    public interface IProcedureRepository
    {
        Task ResetDataAsync();
        Task SeedDataAsync();
    }
}
