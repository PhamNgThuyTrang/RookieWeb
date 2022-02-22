using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewModel.Category
{
    public class CategoryVm
    {
        [Required]
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
