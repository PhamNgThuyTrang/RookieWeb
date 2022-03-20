using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieShop.Shared.Request.Review
{
    public class ReviewEditRequest
    {
        [Range(1, 5, ErrorMessage = "the stars are from 1 to 5")]
        public int Stars { get; set; }

        [MaxLength(2000, ErrorMessage = "the content has max length is 2000")]
        public string Content { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }
    }
}
