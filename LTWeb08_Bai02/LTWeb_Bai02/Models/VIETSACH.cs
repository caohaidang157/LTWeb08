namespace LTWeb_Bai02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIETSACH")]
    public partial class VIETSACH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaTG { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(50)]
        public string VaiTro { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual TACGIA TACGIA { get; set; }
    }
}
