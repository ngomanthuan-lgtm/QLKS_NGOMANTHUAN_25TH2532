using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("KHACHHANG")]
    public class Khachhang25th2532
    {
        [Key]
        public int MaKhachHang { get; set; }

        public string? HoTen { get; set; }

        public string? SoDienThoai { get; set; }

        public string? Email { get; set; }

        public string? SoCCCD { get; set; }
    }
}
