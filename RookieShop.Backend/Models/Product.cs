using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }
        public int ListedPrice { get; set; }
        public int SellingPrice { get; set; }
        public DateTime DateUpload { get; set; }
        public bool IsDeleted { get; set; }

        public int ProductModelId { get; set; }
        public ProductModel ProductModel { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public List<Review> Reviews { get; set; }


        public Product()
        {
            DateUpload = DateTime.Now;
        }
    }
}
