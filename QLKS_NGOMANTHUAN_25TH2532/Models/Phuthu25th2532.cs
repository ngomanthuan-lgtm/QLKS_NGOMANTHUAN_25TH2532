using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("PHUTHU")]
    public class Phuthu25th2532
    {
        [Key]
        public int MaPhuThu { get; set; }

        public string? LyDoPhuThu { get; set; }

        public decimal? SoTienPhuThu { get; set; }
    }
}
