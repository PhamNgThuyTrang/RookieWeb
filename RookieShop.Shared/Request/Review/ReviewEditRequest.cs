using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RookieShop.Shared.Request.Review
{
    public class ReviewEditRequest
    {
        public string Stars { get; set; }

        [MaxLength(2000, ErrorMessage = "the content has max length is 2000")]
        public string Content { get; set; }

        public string ProductId { get; set; }

        public string UserId { get; set; }
    }
}
