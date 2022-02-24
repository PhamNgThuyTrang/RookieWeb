using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModels
{
    public class ProductSizeVm
    {
        public int ProductSizeId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
