using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Models
{
    public class ProductModel
    {
        public int ProductModelId { get; set; }
        public bool IsDeleted { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Product> Products { get; set; }
    }
}
