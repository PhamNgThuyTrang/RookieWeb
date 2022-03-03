using RookieShop.Shared.Dto.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Dto.SubCategory
{
    public class SubCategoryDto
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public CategoryDto Category { get; set; }
        public int CategoryId { get; set; }
    }
}
