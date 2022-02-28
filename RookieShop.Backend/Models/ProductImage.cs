using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
