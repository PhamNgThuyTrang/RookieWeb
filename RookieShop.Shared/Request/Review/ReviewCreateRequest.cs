using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared.Request.Review
{
    public class ReviewCreateRequest
    {
        [Required]
        public int Stars { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
