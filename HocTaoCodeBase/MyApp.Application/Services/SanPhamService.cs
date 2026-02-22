using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Services;

public class SanPhamService : ISanPhamService
{
    private readonly IUnitOfWork _unitOfWork;

    public SanPhamService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<SanPhamDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var entity = await _unitOfWork.SanPhams.GetByIdAsync(id, ct);
        if (entity == null) return null;

        return MapToDto(entity);
    }

    public async Task<IReadOnlyList<SanPhamDto>> GetAllAsync(CancellationToken ct = default)
    {
        var entities = await _unitOfWork.SanPhams.GetAllAsync(ct);
        return entities.Select(MapToDto).ToList();
    }

    public async Task<int> CreateAsync(CreateSanPhamRequest request, CancellationToken ct = default)
    {
        var entity = new SanPham(
            request.Ten,
            request.Gia,
            request.NgayMua,
            request.DangBan,
            request.Loai,
            request.NgayHetHan);

        await _unitOfWork.SanPhams.AddAsync(entity, ct);

        await _unitOfWork.CommitAsync();

        return entity.Id;
    }

    public async Task UpdateGiaAsync(int id, int giaMoi, CancellationToken ct = default)
    {
        var entity = await _unitOfWork.SanPhams.GetByIdAsync(id, ct)
                     ?? throw new InvalidOperationException("Sản phẩm không tồn tại");

        entity.CapNhatGia(giaMoi);

        _unitOfWork.SanPhams.Update(entity);

        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await _unitOfWork.SanPhams.GetByIdAsync(id, ct);

        if (entity == null)
            return;

        _unitOfWork.SanPhams.Remove(entity);

        await _unitOfWork.CommitAsync();
    }

    private static SanPhamDto MapToDto(SanPham entity)
        => new()
        {
            Id = entity.Id,
            Ten = entity.Ten,
            Gia = entity.Gia,
            DangBan = entity.DangBan,
            Loai = entity.Loai
        };
}