using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModels
{
    public class ReviewVm
    {
        public int ReviewId { get; set; }
        public int Stars { get; set; }
        public string Content { get; set; }
        public DateTime DateUpload { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }
        public UserVm User { get; set; }
    }
}
