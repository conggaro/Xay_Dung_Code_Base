using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Repositories;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.EfEntities;

namespace MyApp.Infrastructure.Repositories;

public class SanPhamRepository : ISanPhamRepository
{
    private readonly MyDbContext _context;

    public SanPhamRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<SanPham?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var ef = await _context.SanPhams
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return ef == null ? null : MapToDomain(ef);
    }

    public async Task<IReadOnlyList<SanPham>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _context.SanPhams
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return list.Select(MapToDomain).ToList();
    }

    public async Task AddAsync(SanPham sanPham, CancellationToken cancellationToken = default)
    {
        var ef = MapToEf(sanPham);
        await _context.SanPhams.AddAsync(ef, cancellationToken);
    }

    public void Update(SanPham sanPham)
    {
        var ef = MapToEf(sanPham);
        _context.SanPhams.Update(ef);
    }

    public void Remove(SanPham sanPham)
    {
        var ef = MapToEf(sanPham);
        _context.SanPhams.Remove(ef);
    }

    // =============================
    // Mapping
    // =============================

    private static SanPham MapToDomain(SanPhamEf ef)
    {
        return new SanPham(
            ef.Id,
            ef.TenSanPham ?? string.Empty,
            ef.GiaSanPham ?? 0,
            ef.NgayMuaHang,
            ef.TrangThai ?? false,
            ef.LoaiSanPham,
            ef.NgayHetHang
        );
    }

    private static SanPhamEf MapToEf(SanPham domain)
    {
        return new SanPhamEf
        {
            Id = domain.Id,
            TenSanPham = domain.Ten,
            GiaSanPham = domain.Gia,
            NgayMuaHang = domain.NgayMua,
            TrangThai = domain.DangBan,
            LoaiSanPham = domain.Loai,
            NgayHetHang = domain.NgayHetHan
        };
    }
}