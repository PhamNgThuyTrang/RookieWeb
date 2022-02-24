using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Request
{
    public class ProductModelCreateRequest
    {
        public int ProductModelId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
