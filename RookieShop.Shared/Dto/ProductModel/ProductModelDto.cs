using RookieShop.Shared.Dto.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Dto.ProductModel
{
    public class ProductModelDto
    {
        public int ProductModelId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
