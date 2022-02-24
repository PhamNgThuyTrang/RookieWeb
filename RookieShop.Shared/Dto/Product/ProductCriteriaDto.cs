using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Dto.Product
{
    public class ProductCriteriaDto : BaseQueryCriteriaDto
    {
        public bool GetProductImage { get; set; }
        public bool GetProductSize { get; set; }

        public ProductCriteriaDto()
        {
            GetProductImage = false;
            GetProductSize = false;
        }
    }
}
