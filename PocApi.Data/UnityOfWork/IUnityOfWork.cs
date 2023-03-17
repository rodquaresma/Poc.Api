namespace PocApi.Data.UnityOfWork
{
    public interface IUnityOfWork
    {
        Task CommitAsync();
        Task SaveChangesAsync();
        Task RollbackAsync();
    }
}
