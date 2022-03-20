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
        [MaxLength(100, ErrorMessage = "the name has max length is 100")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "the color has max length is 100")]
        public string Color { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

        [Required]
        [Range(0, 1000000000, ErrorMessage = "the listed price is lower than 1000000000")]
        public int ListedPrice { get; set; }

        [Required]
        [Range(0, 1000000000, ErrorMessage = "the selling price is lower than 1000000000")]
        public int SellingPrice { get; set; }

        [Required]
        public int ProductModelId { get; set; }

    }
}
