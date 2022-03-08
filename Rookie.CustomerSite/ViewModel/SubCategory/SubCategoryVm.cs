using Rookie.CustomerSite.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewModel.SubCategory
{
    public class SubCategoryVm
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public CategoryVm Category { get; set; }
    }
}
