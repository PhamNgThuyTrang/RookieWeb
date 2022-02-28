using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewModel.ProductSize
{
    public class ProductSizeVm
    {
        public int ProductSizeId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
