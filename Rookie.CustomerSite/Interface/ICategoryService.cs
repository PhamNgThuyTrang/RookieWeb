using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Category;
using RookieShop.Shared.ViewModels;
using System.Threading.Tasks;

public interface ICategoryService
{
    Task<PagedResponseDto<CategoryDto>> GetCategoryAsync(CategoryCriteriaDto categoryCriteriaDto);
    Task<CategoryDto> GetCategoryAsyncById(int id);
}