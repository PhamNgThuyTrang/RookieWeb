using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<ActionResult<PagedResponseDto<ProductDto>>> GetProductAsync(ProductCriteriaDto productCriteriaDto)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var getProductsEndpoint = string.IsNullOrEmpty(productCriteriaDto.Search) ?
                                    EndpointConstants.GET_PRODUCTS :
                                    $"{EndpointConstants.GET_PRODUCTS}?Search={productCriteriaDto.Search}";

        var response = await client.GetAsync(getProductsEndpoint);
        response.EnsureSuccessStatusCode();
        var pagedProducts = await response.Content.ReadAsAsync<PagedResponseDto<ProductDto>>();
        return pagedProducts;
    }
    public async Task<ActionResult<ProductDto>> GetProductAsyncById(int id)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_PRODUCTS}\\{id}");
        response.EnsureSuccessStatusCode();
        var product = await response.Content.ReadAsAsync<ProductDto>();
        return product;
    }
}

