using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Dto.ProductSize
{
    public class ProductSizeDto
    {
        public int ProductSizeId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
