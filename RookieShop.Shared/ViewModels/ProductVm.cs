using RookieShop.Shared.Dto.ProductImage;
using RookieShop.Shared.Dto.ProductSize;
using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModels
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
    }
}
