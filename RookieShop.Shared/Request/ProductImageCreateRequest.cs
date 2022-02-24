using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieShop.Shared.Request
{
    public class ProductImageCreateRequest
    {
        [Required]
        public string ImagePath { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
