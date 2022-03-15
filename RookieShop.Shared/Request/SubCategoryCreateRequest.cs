using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared.Request
{
    public class SubCategoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
