using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared.Request.Review
{
    public class ReviewCreateRequest
    {
        [Required]
        public string Stars { get; set; }

        [Required]
        [MaxLength(2000, ErrorMessage = "the content has max length is 2000")]
        public string Content { get; set; }

        [Required]
        public string ProductId { get; set; }

        public string UserId { get; set; }
    }
}
