namespace LTWeb_Bai02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CHITIETDONDATHANG = new HashSet<CHITIETDONDATHANG>();
        }

        [Key]
        [StringLength(10)]
        public string SoDonHang { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        [Column(TypeName = "money")]
        public decimal? TriGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONDATHANG> CHITIETDONDATHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
