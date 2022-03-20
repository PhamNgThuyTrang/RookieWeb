using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using RookieShop.Shared.Enum;

namespace RookieShop.Shared.Request
{
    public class BrandCreateRequest
    {
        [Required]
        [MaxLength(100, ErrorMessage = "the name has max length is 100")]
        public string Name { get; set; }
        [Required]
        public BrandTypeEnum Type { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
