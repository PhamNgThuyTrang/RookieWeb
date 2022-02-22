using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Banner;
using RookieShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class BannerService : IBannerService
{
    private readonly IHttpClientFactory _clientFactory;

    public BannerService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<ActionResult<PagedResponseDto<BannerDto>>> GetBannerAsync(BannerCriteriaDto bannerCriteriaDto)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var getBannersEndpoint = string.IsNullOrEmpty(bannerCriteriaDto.Search) ?
                                    EndpointConstants.GET_BANNERS :
                                    $"{EndpointConstants.GET_BANNERS}?Search={bannerCriteriaDto.Search}";

        var response = await client.GetAsync(getBannersEndpoint);
        response.EnsureSuccessStatusCode();
        var pagedBrands = await response.Content.ReadAsAsync<PagedResponseDto<BannerDto>>();
        return pagedBrands;
    }
    public async Task<ActionResult<BannerDto>> GetBannerAsyncById(int id)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_BANNERS}\\{id}");
        response.EnsureSuccessStatusCode();
        var banner = await response.Content.ReadAsAsync<BannerDto>();
        return banner;
    }
}
