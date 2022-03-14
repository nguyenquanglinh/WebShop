namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductView")]
    public partial class ProductView
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        public long ID_Product { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(200)]
        public string Avatar { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public decimal? Discount { get; set; }

        [StringLength(100)]
        public string Metatitle { get; set; }

        public DateTime? CreateDate { get; set; }

        public long ID_Trademark { get; set; }

        public long? ID_Promotion { get; set; }
    }
}
