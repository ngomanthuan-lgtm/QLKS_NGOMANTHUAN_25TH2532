using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("CHITIET_DATPHONG")]
    public class ChitietDatphong25th2532
    {
        [Key]
        public int MaChiTietDat { get; set; }

        public int? MaDatPhong { get; set; }

        public int? MaPhong { get; set; }

        public DateTime? NgayNhan { get; set; }

        public DateTime? NgayTra { get; set; }

        public decimal? DonGia { get; set; }

        [ForeignKey("MaDatPhong")]
        public virtual Datphong25th2532? MaDatPhongNavigation { get; set; }

        [ForeignKey("MaPhong")]
        public virtual Phong25th2532? MaPhongNavigation { get; set; }
    }
}
