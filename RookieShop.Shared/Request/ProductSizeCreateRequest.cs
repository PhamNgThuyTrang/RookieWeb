using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieShop.Shared.Request
{
    public class ProductSizeCreateRequest
    {
        [Required]
        [MaxLength(100, ErrorMessage = "the size has max length is 10")]
        public string Size { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
