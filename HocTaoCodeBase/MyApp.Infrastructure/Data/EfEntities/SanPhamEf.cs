namespace MyApp.Infrastructure.EfEntities;

public class SanPhamEf
{
    public int Id { get; set; }

    public string? TenSanPham { get; set; }

    public int? GiaSanPham { get; set; }

    public DateOnly? NgayMuaHang { get; set; }

    public bool? TrangThai { get; set; }

    public int? LoaiSanPham { get; set; }

    public DateOnly? NgayHetHang { get; set; }
}