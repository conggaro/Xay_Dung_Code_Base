using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Infrastructure.EfEntities;

namespace MyApp.Infrastructure.Configurations;

public class SanPhamConfiguration : IEntityTypeConfiguration<SanPhamEf>
{
    public void Configure(EntityTypeBuilder<SanPhamEf> entity)
    {
        entity.ToTable("SanPham", "dbo");

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
              .ValueGeneratedOnAdd();

        entity.Property(e => e.TenSanPham)
              .HasMaxLength(50)
              .HasColumnName("TenSanPham");

        entity.Property(e => e.GiaSanPham)
              .HasColumnName("GiaSanPham");

        entity.Property(e => e.NgayMuaHang)
              .HasColumnType("date")
              .HasColumnName("NgayMuaHang");

        entity.Property(e => e.TrangThai)
              .HasColumnName("TrangThai");

        entity.Property(e => e.LoaiSanPham)
              .HasColumnName("LoaiSanPham");

        entity.Property(e => e.NgayHetHang)
              .HasColumnType("date")
              .HasColumnName("NgayHetHang");
    }
}