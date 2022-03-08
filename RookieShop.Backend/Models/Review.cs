using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Stars { get; set; }
        public string Content { get; set; }
        public DateTime DateUpload { get; set; }
        public bool IsDeleted { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public Review()
        {
            DateUpload = DateTime.Now;
        }
    }
}
