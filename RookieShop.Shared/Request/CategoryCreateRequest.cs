using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared.Request
{
    public class CategoryCreateRequest
    {
        [MaxLength(100, ErrorMessage = "the name has max length is 100")]
        [Required]
        public string Name { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
