using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Request.Review
{
    public class ReviewEditRequest
    {
        public int Stars { get; set; }

        public string Content { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }
    }
}
