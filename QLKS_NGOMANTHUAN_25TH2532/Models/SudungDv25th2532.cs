using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("SUDUNG_DV")]
    public class SudungDv25th2532
    {
        [Key]
        public int MaSuDungDV { get; set; }

        public int? MaChiTietDat { get; set; }

        public int? MaDichVu { get; set; }

        public DateTime? NgaySuDung { get; set; }

        [ForeignKey("MaChiTietDat")]
        public virtual ChitietDatphong25th2532? MaChiTietDatNavigation { get; set; }

        [ForeignKey("MaDichVu")]
        public virtual Dichvu25th2532? MaDichVuNavigation { get; set; }
    }
}
