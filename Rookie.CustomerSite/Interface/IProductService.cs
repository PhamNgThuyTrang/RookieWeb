﻿using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Product;
using System.Threading.Tasks;
public interface IProductService
{
    Task<PagedResponseDto<ProductDto>> GetProductAsync(ProductCriteriaDto productCriteriaDto);

    Task<PagedResponseDto<ProductDto>> GetProductsAsyncByProductModelId(int productModelId);

    Task<PagedResponseDto<ProductDto>> GetProductsBySubCategoryId(int subCategoryId);

    Task<ProductDto> GetProductAsyncById(int? id);
}
