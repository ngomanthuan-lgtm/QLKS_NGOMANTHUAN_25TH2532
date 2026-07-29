using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("PHONG")]
    public class Phong25th2532
    {
        public Phong25th2532()
        {
            MaChiNhanhs = new HashSet<Chinhanh25th2532>();
        }

        [Key]
        public int MaPhong { get; set; }

        public string? SoPhong { get; set; }

        public int? MaLoaiPhong { get; set; }

        public int? MaTrangThai { get; set; }

        [ForeignKey("MaLoaiPhong")]
        public virtual Loaiphong25th2532? MaLoaiPhongNavigation { get; set; }

        [ForeignKey("MaTrangThai")]
        public virtual Trangthaiphong25th2532? MaTrangThaiNavigation { get; set; }

        public virtual ICollection<Chinhanh25th2532> MaChiNhanhs { get; set; }
    }
}
