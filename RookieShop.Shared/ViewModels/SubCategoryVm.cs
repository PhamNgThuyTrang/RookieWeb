using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModels
{
    public class SubCategoryVm
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
    }
}
