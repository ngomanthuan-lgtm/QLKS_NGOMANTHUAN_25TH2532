using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("KHUYENMAI")]
    public class Khuyenmai25th2532
    {
        [Key]
        public int MaKhuyenMai { get; set; }

        public string? TenKhuyenMai { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }
    }
}
