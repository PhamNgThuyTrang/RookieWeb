using Rookie.CustomerSite.ViewModel.ProductImage;
using Rookie.CustomerSite.ViewModel.ProductSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewModel.Product
{
    public class ProductVm
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }
        public int ListedPrice { get; set; }
        public int SellingPrice { get; set; }
        public DateTime DateUpload { get; set; }

        public int ProductModelId { get; set; }

        public List<ProductImageVm> ProductImages { get; set; }
        public List<ProductSizeVm> ProductSizes { get; set; }
    }
}
