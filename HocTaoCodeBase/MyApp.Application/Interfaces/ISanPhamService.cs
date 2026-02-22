using MyApp.Application.DTOs;

namespace MyApp.Application.Services;

public interface ISanPhamService
{
    Task<SanPhamDto?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IReadOnlyList<SanPhamDto>> GetAllAsync(CancellationToken ct = default);
    Task<int> CreateAsync(CreateSanPhamRequest request, CancellationToken ct = default);
    Task UpdateGiaAsync(int id, int giaMoi, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}