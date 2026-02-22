namespace MyApp.Domain.Entities;

public class SanPham
{
    public int Id { get; }
    public string Ten { get; private set; }
    public int Gia { get; private set; }
    public DateOnly? NgayMua { get; private set; }
    public bool DangBan { get; private set; }
    public int? Loai { get; private set; }
    public DateOnly? NgayHetHan { get; private set; }

    // Constructor dùng khi load từ DB
    public SanPham(
        int id,
        string ten,
        int gia,
        DateOnly? ngayMua,
        bool dangBan,
        int? loai,
        DateOnly? ngayHetHan)
        : this(ten, gia, ngayMua, dangBan, loai, ngayHetHan)
    {
        Id = id;
    }

    // Constructor dùng khi tạo mới
    public SanPham(
        string ten,
        int gia,
        DateOnly? ngayMua,
        bool dangBan,
        int? loai,
        DateOnly? ngayHetHan)
    {
        SetTen(ten);
        SetGia(gia);

        NgayMua = ngayMua;
        DangBan = dangBan;
        Loai = loai;
        NgayHetHan = ngayHetHan;
    }

    private void SetTen(string ten)
    {
        if (string.IsNullOrWhiteSpace(ten))
            throw new ArgumentException("Tên không được rỗng");

        Ten = ten;
    }

    private void SetGia(int gia)
    {
        if (gia <= 0)
            throw new ArgumentException("Giá phải lớn hơn 0");

        Gia = gia;
    }

    public void CapNhatGia(int giaMoi)
    {
        SetGia(giaMoi);
    }
}