using RookieShop.Shared.Dto.Product;
using RookieShop.Shared.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Dto.Review
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int Stars { get; set; }
        public string Content { get; set; }
        public DateTime DateUpload { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}
