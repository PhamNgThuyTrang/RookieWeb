using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared.Request
{
    public class CategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
