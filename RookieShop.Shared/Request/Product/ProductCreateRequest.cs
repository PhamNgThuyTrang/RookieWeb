using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieShop.Shared.Request.Product
{
    public class ProductCreateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
        [Required]
        public int ListedPrice { get; set; }
        [Required]
        public int SellingPrice { get; set; }
        [Required]
        public int ProductModelId { get; set; }

    }
}
