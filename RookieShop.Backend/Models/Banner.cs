using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Banner
    {
        public int BannerId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateUpload { get; set; }
        public bool IsDeleted { get; set; }

        public Banner()
        {
            DateUpload = DateTime.Now;
        }
    }
}
