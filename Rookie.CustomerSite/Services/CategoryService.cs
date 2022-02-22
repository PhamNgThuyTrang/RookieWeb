using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Category;
using RookieShop.Shared.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _clientFactory;

    public CategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<ActionResult<PagedResponseDto<CategoryDto>>> GetCategoryAsync(CategoryCriteriaDto categoryCriteriaDto)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var getCategoriesEndpoint = string.IsNullOrEmpty(categoryCriteriaDto.Search) ?
                                    EndpointConstants.GET_CATEGORIES :
                                    $"{EndpointConstants.GET_CATEGORIES}?Search={categoryCriteriaDto.Search}";

        var response = await client.GetAsync(getCategoriesEndpoint);
        response.EnsureSuccessStatusCode();
        var pagedCategories = await response.Content.ReadAsAsync<PagedResponseDto<CategoryDto>>();
        return pagedCategories;
    }
    public async Task<ActionResult<CategoryDto>> GetCategoryAsyncById(int id)
    {
        var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
        var response = await client.GetAsync($"{EndpointConstants.GET_CATEGORIES}\\{id}");
        response.EnsureSuccessStatusCode();
        var category = await response.Content.ReadAsAsync<CategoryDto>();
        return category;
    }
}

