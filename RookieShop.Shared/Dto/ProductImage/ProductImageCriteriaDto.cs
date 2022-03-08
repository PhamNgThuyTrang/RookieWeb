using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.Dto.ProductImage
{
    public class ProductImageCriteriaDto : BaseQueryCriteriaDto
    {
        public int ProductId { get; set; }
    }
}
