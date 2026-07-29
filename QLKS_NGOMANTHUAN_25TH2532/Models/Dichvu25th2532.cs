using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("DICHVU")]
    public class Dichvu25th2532
    {
        [Key]
        public int MaDichVu { get; set; }

        public string? TenDichVu { get; set; }

        public decimal? GiaDichVu { get; set; }
    }
}
