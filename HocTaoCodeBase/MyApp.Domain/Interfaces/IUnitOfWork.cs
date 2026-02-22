using MyApp.Domain.Repositories;

namespace MyApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISanPhamRepository SanPhams { get; }

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        Task<int> CommitAsync();
    }
}