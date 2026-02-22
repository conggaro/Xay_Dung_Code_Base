public class CreateSanPhamRequest
{
    public string Ten { get; init; } = default!;
    public int Gia { get; init; }
    public DateOnly? NgayMua { get; init; }
    public bool DangBan { get; init; }
    public int? Loai { get; init; }
    public DateOnly? NgayHetHan { get; init; }
}