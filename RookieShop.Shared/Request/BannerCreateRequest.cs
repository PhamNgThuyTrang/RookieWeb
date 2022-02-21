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
        public string Name { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
