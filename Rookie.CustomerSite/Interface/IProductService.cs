using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public interface IProductService
{
    Task<ActionResult<PagedResponseDto<ProductDto>>> GetProductAsync(ProductCriteriaDto productCriteriaDto);
    Task<ActionResult<ProductDto>> GetProductAsyncById(int id);
}
