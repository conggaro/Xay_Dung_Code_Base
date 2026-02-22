using MyApp.Domain.Entities;

namespace MyApp.Domain.Repositories;

public interface ISanPhamRepository
{
    Task<SanPham?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<SanPham>> GetAllAsync(CancellationToken cancellationToken = default);

    Task AddAsync(SanPham sanPham, CancellationToken cancellationToken = default);

    void Update(SanPham sanPham);

    void Remove(SanPham sanPham);
}