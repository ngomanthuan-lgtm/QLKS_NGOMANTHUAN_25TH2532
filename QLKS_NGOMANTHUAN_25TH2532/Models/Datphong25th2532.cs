using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("DATPHONG")]
    public class Datphong25th2532
    {
        public Datphong25th2532()
        {
            ChitietDatphongs = new HashSet<ChitietDatphong25th2532>();
        }

        [Key]
        public int MaDatPhong { get; set; }

        public DateTime? NgayDat { get; set; }

        public string? TinhTrangDat { get; set; }

        public string? HoTenNguoiDat { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        public string? DiaChi { get; set; }

        public string? SoDienThoai { get; set; }

        public string? Email { get; set; }

        public decimal? TienDatCoc { get; set; }

        // --- Thuộc tính liên kết khóa ngoại mới ---
        [Display(Name = "Chọn Phòng đặt")]
        public int? MaPhong { get; set; }

        [ForeignKey("MaPhong")]
        public virtual Phong25th2532? MaPhongNavigation { get; set; }

        public virtual ICollection<ChitietDatphong25th2532> ChitietDatphongs { get; set; }
    }
}
