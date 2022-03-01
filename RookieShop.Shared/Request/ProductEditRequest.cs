using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Request
{
    public class ProductEditRequest
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public IFormFile ImageFile { get; set; }
        public int ListedPrice { get; set; }
        public int SellingPrice { get; set; }
        public int ProductModelId { get; set; }

        public ProductEditRequest()
        {
            ListedPrice = 0;
            SellingPrice = 0;
            ProductModelId = 0;
        }
    }
}
