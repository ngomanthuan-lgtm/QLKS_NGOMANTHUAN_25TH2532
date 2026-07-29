using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLKS_NGOMANTHUAN_25TH2532.Models
{
    [Table("TRANGTHAIPHONG")]
    public class Trangthaiphong25th2532
    {
        public Trangthaiphong25th2532()
        {
            Phongs = new HashSet<Phong25th2532>();
        }

        [Key]
        public int MaTrangThai { get; set; }

        public string? TenTrangThai { get; set; }

        public virtual ICollection<Phong25th2532> Phongs { get; set; }
    }
}
