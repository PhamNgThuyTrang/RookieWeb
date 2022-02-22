using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Category;
using RookieShop.Shared.ViewModels;
using System.Threading.Tasks;

public interface ICategoryService
{
    Task<ActionResult<PagedResponseDto<CategoryDto>>> GetCategoryAsync(CategoryCriteriaDto categoryCriteriaDto);
    Task<ActionResult<CategoryDto>> GetCategoryAsyncById(int id);
}