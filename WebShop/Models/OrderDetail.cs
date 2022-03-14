namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        public long ID_OrderDetail { get; set; }

        public long ID_Order { get; set; }

        public int? Quantity { get; set; }

        public decimal? TotalPrice { get; set; }

        public long? ID_Product { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
