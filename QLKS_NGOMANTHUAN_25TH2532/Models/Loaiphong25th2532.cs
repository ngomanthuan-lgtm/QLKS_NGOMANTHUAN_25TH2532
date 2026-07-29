using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("LOAIPHONG")]
    public class Loaiphong25th2532
    {
        public Loaiphong25th2532()
        {
            Phongs = new HashSet<Phong25th2532>();
        }

        [Key]
        public int MaLoaiPhong { get; set; }

        public string? TenLoaiPhong { get; set; }

        public decimal? GiaPhong { get; set; }

        public string? MoTa { get; set; }

        public virtual ICollection<Phong25th2532> Phongs { get; set; }
    }
}
