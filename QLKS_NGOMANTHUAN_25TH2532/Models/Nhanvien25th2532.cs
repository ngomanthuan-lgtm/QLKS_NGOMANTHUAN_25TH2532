using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("NHANVIEN")]
    public class Nhanvien25th2532
    {
        [Key]
        public int MaNhanVien { get; set; }

        public string? HoTen { get; set; }

        public string? ChucVu { get; set; }

        public decimal? Luong { get; set; }
    }
}
