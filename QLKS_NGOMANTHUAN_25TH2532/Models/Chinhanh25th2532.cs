using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("CHINHANH")]
    public class Chinhanh25th2532
    {
        [Key]
        public int MaChiNhanh { get; set; }

        public string? TenChiNhanh { get; set; }

        public string? DiaChi { get; set; }

        public string? SoDienThoai { get; set; }
    }
}
