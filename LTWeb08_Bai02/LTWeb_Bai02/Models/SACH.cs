namespace LTWeb_Bai02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CHITIETDONDATHANG = new HashSet<CHITIETDONDATHANG>();
            VIETSACH = new HashSet<VIETSACH>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(200)]
        public string TenSach { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaBan { get; set; }

        public string MoTa { get; set; }

        [StringLength(255)]
        public string AnhBia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }

        public int? SoLuongTon { get; set; }

        [StringLength(10)]
        public string MaCD { get; set; }

        [StringLength(10)]
        public string MaNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONDATHANG> CHITIETDONDATHANG { get; set; }

        public virtual CHUDE CHUDE { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIETSACH> VIETSACH { get; set; }
    }
}
