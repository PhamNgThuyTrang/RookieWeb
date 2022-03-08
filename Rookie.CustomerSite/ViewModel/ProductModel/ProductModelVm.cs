using Rookie.CustomerSite.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewModel.ProductModel
{
    public class ProductModelVm
    {
        public int ProductModelId { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategoryVm SubCategory { get; set; }
        public int BrandId { get; set; }
    }
}
