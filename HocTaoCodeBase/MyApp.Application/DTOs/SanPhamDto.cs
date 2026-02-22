namespace MyApp.Application.DTOs;

public class SanPhamDto
{
    public int Id { get; init; }
    public string Ten { get; init; } = default!;
    public int Gia { get; init; }
    public bool DangBan { get; init; }
    public int? Loai { get; init; }
}