using Newtonsoft.Json;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.ProductSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


public class ProductSizeService : IProductSizeService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProductSizeService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<PagedResponseDto<ProductSizeDto>> GetProductSizesAsync(ProductSizeCriteriaDto productSizeCriteriaDto)
    { 
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var getProductSizesEndpoint = (productSizeCriteriaDto.ProductId == null) ?
                                    EndpointConstants.GET_PRODUCT_SIZES :
                                    $"{EndpointConstants.GET_PRODUCT_SIZES}?ProductId={productSizeCriteriaDto.ProductId}";

        var response = await client.GetAsync(getProductSizesEndpoint);
        response.EnsureSuccessStatusCode();
        var pagedProductSizes = await response.Content.ReadAsAsync<PagedResponseDto<ProductSizeDto>>();
        return pagedProductSizes;
    }
    public async Task<ProductSizeDto> GetProductSizeAsyncById(int id)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_PRODUCT_SIZES}\\{id}");
        response.EnsureSuccessStatusCode();
        var productSize = await response.Content.ReadAsAsync<ProductSizeDto>();
        return productSize;
    }
}

