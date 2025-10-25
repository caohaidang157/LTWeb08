namespace LTWeb_Bai02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONDATHANG")]
    public partial class CHITIETDONDATHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SoDonHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSach { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGia { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual DONDATHANG DONDATHANG { get; set; }
    }
}
