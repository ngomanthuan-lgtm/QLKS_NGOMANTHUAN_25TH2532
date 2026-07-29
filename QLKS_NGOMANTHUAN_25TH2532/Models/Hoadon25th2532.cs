using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("HOADON")]
    public class Hoadon25th2532
    {
        public Hoadon25th2532()
        {
            // Khởi tạo tập hợp liên kết nhiều-nhiều với Khuyến mãi
            MaKhuyenMais = new HashSet<Khuyenmai25th2532>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        public DateTime? NgayLap { get; set; }

        public decimal? TongTienPhong { get; set; }

        public decimal? TongTienDichVu { get; set; }

        public decimal? ThanhTien { get; set; }

        public int? MaChiTietDat { get; set; }

        [ForeignKey("MaChiTietDat")]
        public virtual ChitietDatphong25th2532? MaChiTietDatNavigation { get; set; }

        // Thuộc tính cốt lõi để sửa lỗi HasMany(d => d.MaKhuyenMais)
        public virtual ICollection<Khuyenmai25th2532> MaKhuyenMais { get; set; }
    }
}
