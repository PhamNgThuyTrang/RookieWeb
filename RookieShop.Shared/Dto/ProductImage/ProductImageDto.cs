using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Dto.ProductImage
{
    public class ProductImageDto
    {
        public int ProductImageId { get; set; }
        public string ImagePath { get; set; }

        public int ProductId { get; set; }
    }
}
