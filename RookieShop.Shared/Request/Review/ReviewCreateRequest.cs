using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared.Request.Review
{
    public class ReviewCreateRequest
    {
        [Required]
        [Range(1, 5, ErrorMessage = "the stars are from 1 to 5")]
        public int Stars { get; set; }

        [Required]
        [MaxLength(2000, ErrorMessage = "the content has max length is 2000")]
        public string Content { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string UserId { get; set; }
    }
}
