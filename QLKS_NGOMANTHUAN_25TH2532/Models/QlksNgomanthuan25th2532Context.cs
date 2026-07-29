using Microsoft.EntityFrameworkCore;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    public class QlksNgomanthuan25th2532Context : DbContext
    {
        public QlksNgomanthuan25th2532Context() { }

        public QlksNgomanthuan25th2532Context(DbContextOptions<QlksNgomanthuan25th2532Context> options)
            : base(options) { }

        // Khai báo trọn bộ DbSet đồng bộ mã sinh viên 25th2532
        public virtual DbSet<Chinhanh25th2532> Chinhanhs { get; set; } = null!;
        public virtual DbSet<Trangthaiphong25th2532> Trangthaiphongs { get; set; } = null!;
        public virtual DbSet<Loaiphong25th2532> Loaiphongs { get; set; } = null!;
        public virtual DbSet<Phong25th2532> Phongs { get; set; } = null!;
        public virtual DbSet<Nhanvien25th2532> Nhanviens { get; set; } = null!;
        public virtual DbSet<Khachhang25th2532> Khachhangs { get; set; } = null!;
        public virtual DbSet<Dichvu25th2532> Dichvus { get; set; } = null!;
        public virtual DbSet<Khuyenmai25th2532> Khuyenmais { get; set; } = null!;
        public virtual DbSet<Phuthu25th2532> Phuthus { get; set; } = null!;
        public virtual DbSet<Datphong25th2532> Datphongs { get; set; } = null!;
        public virtual DbSet<ChitietDatphong25th2532> ChitietDatphongs { get; set; } = null!;
        public virtual DbSet<SudungDv25th2532> SudungDvs { get; set; } = null!;
        public virtual DbSet<Hoadon25th2532> Hoadons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. CHI NHÁNH
            modelBuilder.Entity<Chinhanh25th2532>(entity => {
                entity.ToTable("CHINHANH");
                entity.HasKey(e => e.MaChiNhanh);
                entity.Property(e => e.TenChiNhanh).HasMaxLength(150);
                entity.Property(e => e.DiaChi).HasMaxLength(255);
                entity.Property(e => e.SoDienThoai).HasMaxLength(15).IsUnicode(false);
            });

            // 2. TRẠNG THÁI PHÒNG
            modelBuilder.Entity<Trangthaiphong25th2532>(entity => {
                entity.ToTable("TRANGTHAIPHONG");
                entity.HasKey(e => e.MaTrangThai);
                entity.Property(e => e.TenTrangThai).HasMaxLength(50);
            });

            // 3. LOẠI PHÒNG
            modelBuilder.Entity<Loaiphong25th2532>(entity => {
                entity.ToTable("LOAIPHONG");
                entity.HasKey(e => e.MaLoaiPhong);
                entity.Property(e => e.TenLoaiPhong).HasMaxLength(100);
                entity.Property(e => e.GiaPhong).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MoTa).HasMaxLength(500);
            });

            // 4. PHÒNG
            modelBuilder.Entity<Phong25th2532>(entity => {
                entity.ToTable("PHONG");
                entity.HasKey(e => e.MaPhong);
                entity.Property(e => e.SoPhong).HasMaxLength(10).IsUnicode(false);
                entity.HasOne(d => d.MaLoaiPhongNavigation).WithMany(p => p.Phongs).HasForeignKey(d => d.MaLoaiPhong);
                entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.Phongs).HasForeignKey(d => d.MaTrangThai);

                entity.HasMany(d => d.MaChiNhanhs).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PHONG_CHINHANH",
                        l => l.HasOne<Chinhanh25th2532>().WithMany().HasForeignKey("MaChiNhanh"),
                        r => r.HasOne<Phong25th2532>().WithMany().HasForeignKey("MaPhong"),
                        j => {
                            j.ToTable("PHONG_CHINHANH");
                            j.HasKey("MaPhong", "MaChiNhanh");
                        });
            });

            // 5. NHÂN VIÊN
            modelBuilder.Entity<Nhanvien25th2532>(entity => {
                entity.ToTable("NHANVIEN");
                entity.HasKey(e => e.MaNhanVien);
                entity.Property(e => e.HoTen).HasMaxLength(100);
                entity.Property(e => e.ChucVu).HasMaxLength(50);
                entity.Property(e => e.Luong).HasColumnType("decimal(18, 2)");
            });

            // 6. KHÁCH HÀNG
            modelBuilder.Entity<Khachhang25th2532>(entity => {
                entity.ToTable("KHACHHANG");
                entity.HasKey(e => e.MaKhachHang);
                entity.Property(e => e.HoTen).HasMaxLength(100);
                entity.Property(e => e.SoDienThoai).HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.SoCCCD).HasMaxLength(20).IsUnicode(false);
            });

            // 7. DỊCH VỤ
            modelBuilder.Entity<Dichvu25th2532>(entity => {
                entity.ToTable("DICHVU");
                entity.HasKey(e => e.MaDichVu);
                entity.Property(e => e.TenDichVu).HasMaxLength(100);
                entity.Property(e => e.GiaDichVu).HasColumnType("decimal(18, 2)");
            });

            // 8. KHUYẾN MÃI
            modelBuilder.Entity<Khuyenmai25th2532>(entity => {
                entity.ToTable("KHUYENMAI");
                entity.HasKey(e => e.MaKhuyenMai);
                entity.Property(e => e.TenKhuyenMai).HasMaxLength(100);
                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            });

            // 9. PHỤ THU
            modelBuilder.Entity<Phuthu25th2532>(entity => {
                entity.ToTable("PHUTHU");
                entity.HasKey(e => e.MaPhuThu);
                entity.Property(e => e.LyDoPhuThu).HasMaxLength(200);
                entity.Property(e => e.SoTienPhuThu).HasColumnType("decimal(18, 2)");
            });

            // 10. ĐẶT PHÒNG
            modelBuilder.Entity<Datphong25th2532>(entity => {
                entity.ToTable("DATPHONG");
                entity.HasKey(e => e.MaDatPhong);
                entity.Property(e => e.NgayDat).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.TinhTrangDat).HasMaxLength(50);
            });

            // 11. CHI TIẾT ĐẶT PHÒNG
            modelBuilder.Entity<ChitietDatphong25th2532>(entity => {
                entity.ToTable("CHITIET_DATPHONG");
                entity.HasKey(e => e.MaChiTietDat);
                entity.Property(e => e.NgayNhan).HasColumnType("datetime");
                entity.Property(e => e.NgayTra).HasColumnType("datetime");
                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
                entity.HasOne(d => d.MaDatPhongNavigation).WithMany(p => p.ChitietDatphongs).HasForeignKey(d => d.MaDatPhong);
                entity.HasOne(d => d.MaPhongNavigation).WithMany().HasForeignKey(d => d.MaPhong);
            });

            // 12. SỬ DỤNG DỊCH VỤ
            modelBuilder.Entity<SudungDv25th2532>(entity => {
                entity.ToTable("SUDUNG_DV");
                entity.HasKey(e => e.MaSuDungDV);
                entity.Property(e => e.NgaySuDung).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.HasOne(d => d.MaChiTietDatNavigation).WithMany().HasForeignKey(d => d.MaChiTietDat);
                entity.HasOne(d => d.MaDichVuNavigation).WithMany().HasForeignKey(d => d.MaDichVu);
            });

            // 13. HÓA ĐƠN & LIÊN KẾT NHIỀU - NHIỀU NÂNG CAO
            modelBuilder.Entity<Hoadon25th2532>(entity => {
                entity.ToTable("HOADON");
                entity.HasKey(e => e.MaHoaDon);
                entity.Property(e => e.NgayLap).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.TongTienPhong).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TongTienDichVu).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");
                entity.HasOne(d => d.MaChiTietDatNavigation).WithMany().HasForeignKey(d => d.MaChiTietDat);

                entity.HasMany(d => d.MaKhuyenMais)
                    .WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HOA_DON_KHUYEN_MAI",
                        l => l.HasOne<Khuyenmai25th2532>().WithMany().HasForeignKey("MaKhuyenMai"),
                        r => r.HasOne<Hoadon25th2532>().WithMany().HasForeignKey("MaHoaDon"),
                        j => {
                            j.ToTable("HOA_DON_KHUYEN_MAI");
                            j.HasKey("MaHoaDon", "MaKhuyenMai");
                        });
            });
        }
    }
}
