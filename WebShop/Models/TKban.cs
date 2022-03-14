using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class TKban
    {
        public long ID_Product { get; set; }

        public string Name { get; set; }

        public int? totalQuan { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}