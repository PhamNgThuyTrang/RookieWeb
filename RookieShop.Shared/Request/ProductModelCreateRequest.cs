using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieShop.Shared.Request
{
    public class ProductModelCreateRequest
    {
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public int BrandId { get; set; }
    }
}
