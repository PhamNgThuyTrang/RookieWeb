using System;

namespace RookieShop.Backend.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
    }
}
