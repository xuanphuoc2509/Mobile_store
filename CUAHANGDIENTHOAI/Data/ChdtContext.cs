using System;
using System.Collections.Generic;
using CUAHANGDIENTHOAI.Models;
using Microsoft.EntityFrameworkCore;

namespace CUAHANGDIENTHOAI.Data;

public partial class ChdtContext : DbContext
{
    public ChdtContext()
    {
    }

    public ChdtContext(DbContextOptions<ChdtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<DONHANG> DONHANGs { get; set; }

    public virtual DbSet<HANG> HANGs { get; set; }

    public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }

    public virtual DbSet<SANPHAM> SANPHAMs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-I1S5SR8;Initial Catalog=CuaHangDienThoaiMini;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => e.CHITIETID).HasName("PK__ChiTietD__44A7DE7B3E5069AE");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.DONGIA).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.THANHTIEN)
                .HasComputedColumnSql("([SoLuong]*[DonGia])", true)
                .HasColumnType("decimal(29, 2)");

            entity.HasOne(d => d.DONHANG).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.DONHANGID)
                .HasConstraintName("FK_CT_Don");

            entity.HasOne(d => d.SANPHAM).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.SANPHAMID)
                .HasConstraintName("FK_CT_SanPham");
        });

        modelBuilder.Entity<DONHANG>(entity =>
        {
            entity.HasKey(e => e.DONHANGID).HasName("PK__DONHANG__0CC1A4F2BCF03887");

            entity.ToTable("DONHANG");

            entity.Property(e => e.DIACHINHAN).HasMaxLength(300);
            entity.Property(e => e.DIENTHOAINGUOINHAN).HasMaxLength(30);
            entity.Property(e => e.GIAMGIA).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NGAYDAT).HasColumnType("datetime");
            entity.Property(e => e.PHISHIP).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TAMTINH).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TENNGUOINHAN).HasMaxLength(120);
            entity.Property(e => e.TONGTIEN).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TRANGTHAI).HasMaxLength(20);

            entity.HasOne(d => d.KHACHHANG).WithMany(p => p.DONHANGs)
                .HasForeignKey(d => d.KHACHHANGID)
                .HasConstraintName("FK_DONHANG_KHACH");
        });

        modelBuilder.Entity<HANG>(entity =>
        {
            entity.HasKey(e => e.HANGID).HasName("PK__HANG__D06EB1B833A6F8EC");

            entity.ToTable("HANG");

            entity.Property(e => e.TenHang).HasMaxLength(100);
        });

        modelBuilder.Entity<KHACHHANG>(entity =>
        {
            entity.HasKey(e => e.KHACHHANGID).HasName("PK__KHACHHAN__25C9DB878B93FB5E");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.DIENTHOAI)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EMAIL).HasMaxLength(255);
            entity.Property(e => e.HOTEN).HasMaxLength(120);
            entity.Property(e => e.NGAYTAO).HasColumnType("datetime");
        });

        modelBuilder.Entity<SANPHAM>(entity =>
        {
            entity.HasKey(e => e.SANPHAMID).HasName("PK__SANPHAM__0AE4F5935EA6E5C7");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.GIA).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TENSANPHAM).HasMaxLength(150);
            entity.Property(e => e.TRANGTHAI).HasMaxLength(20);

            entity.HasOne(d => d.HANG).WithMany(p => p.SANPHAMs)
                .HasForeignKey(d => d.HANGID)
                .HasConstraintName("FK_SANPHAM_HANG");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
