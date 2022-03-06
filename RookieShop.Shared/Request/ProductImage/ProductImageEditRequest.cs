using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Request.ProductImage
{
    public class ProductImageEditRequest
    {
        public IFormFile ImageFile { get; set; }

        public int? ProductId { get; set; }
    }
}
