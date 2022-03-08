using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class ProductSize
    {
        public int ProductSizeId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
