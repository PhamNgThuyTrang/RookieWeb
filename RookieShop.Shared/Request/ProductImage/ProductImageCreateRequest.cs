using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieShop.Shared.Request.ProductImage
{
    public class ProductImageCreateRequest
    {
        [Required]
        public IFormFile ImageFile { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
