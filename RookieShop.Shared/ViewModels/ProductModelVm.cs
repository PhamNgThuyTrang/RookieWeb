using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModels
{
    public class ProductModelVm
    {
        public int ProductModelId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public List<ProductVm> Products { get; set; }
    }
}
