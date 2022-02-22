using Rookie.CustomerSite.ViewModel.SubCategory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.CustomerSite.ViewModel.Category
{
    public class CategoryVm
    {
        [Required]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<SubCategoryVm> SubCategories {get;set;}
    }
}
