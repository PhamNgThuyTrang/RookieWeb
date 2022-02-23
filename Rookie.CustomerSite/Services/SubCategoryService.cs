using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class SubCategoryService : ISubCategoryService
{
    private readonly IHttpClientFactory _clientFactory;

    public SubCategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<PagedResponseDto<SubCategoryDto>> GetSubCategoryAsync(SubCategoryCriteriaDto subCategoryCriteriaDto)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var getSubCategoriesEndpoint = string.IsNullOrEmpty(subCategoryCriteriaDto.Search) ?
                                    EndpointConstants.GET_SUBCATEGORIES :
                                    $"{EndpointConstants.GET_SUBCATEGORIES}?Search={subCategoryCriteriaDto.Search}";
        getSubCategoriesEndpoint = subCategoryCriteriaDto.CategoryId == 0 ?
                                   getSubCategoriesEndpoint:
                                   getSubCategoriesEndpoint + $"?CategoryId={subCategoryCriteriaDto.CategoryId}";

        var response = await client.GetAsync(getSubCategoriesEndpoint);
        response.EnsureSuccessStatusCode();
        var pagedSubCategories = await response.Content.ReadAsAsync<PagedResponseDto<SubCategoryDto>>();
        return pagedSubCategories;
    }

    public async Task<SubCategoryDto> GetSubCategoryAsyncById(int id)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_SUBCATEGORIES}\\{id}");
        response.EnsureSuccessStatusCode();
        var subCategory = await response.Content.ReadAsAsync<SubCategoryDto>();
        return subCategory;
    }
}
