using Microsoft.EntityFrameworkCore.Storage;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Repositories;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        private IDbContextTransaction? _transaction;

        public ISanPhamRepository SanPhams { get; }

        public UnitOfWork(MyDbContext context,
                          ISanPhamRepository sanPhamRepository)
        {
            _context = context;
            SanPhams = sanPhamRepository;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction!.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction!.RollbackAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
