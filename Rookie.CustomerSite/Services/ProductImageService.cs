using Rookie.CustomerSite.ViewModel.ProductImage;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Product;
using RookieShop.Shared.Dto.ProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class ProductImageService : IProductImageService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProductImageService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<PagedResponseDto<ProductImageDto>> GetProductImageAsync(ProductImageCriteriaDto productImageCriteriaDto)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var getProductImagesEndpoint = (productImageCriteriaDto.ProductId == null) ?
                                    EndpointConstants.GET_PRODUCT_IMAGES :
                                    $"{EndpointConstants.GET_PRODUCT_IMAGES}?ProductId={productImageCriteriaDto.ProductId}";
        var response = await client.GetAsync(getProductImagesEndpoint);
        response.EnsureSuccessStatusCode();
        var pagedProductImages = await response.Content.ReadAsAsync<PagedResponseDto<ProductImageDto>>();
        return pagedProductImages;
    }
    public async Task<ProductImageDto> GetProductImageAsyncById(int? id)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_PRODUCT_IMAGES}\\{id}");
        response.EnsureSuccessStatusCode();
        var productImage = await response.Content.ReadAsAsync<ProductImageDto>();
        return productImage;
    }
}

