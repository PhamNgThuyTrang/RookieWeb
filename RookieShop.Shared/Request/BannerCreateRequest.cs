using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieShop.Shared.Request
{
    public class BannerCreateRequest
    {
        [Required]
        [MaxLength(100, ErrorMessage = "the name has max length is 100")]
        public string Name { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
