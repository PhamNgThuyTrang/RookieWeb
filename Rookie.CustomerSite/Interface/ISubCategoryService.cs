using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.SubCategory;
using RookieShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface ISubCategoryService
{
    Task<PagedResponseDto<SubCategoryDto>> GetSubCategoryAsync(SubCategoryCriteriaDto subCategoryCriteriaDto);
    Task<SubCategoryDto> GetSubCategoryAsyncById(int id);
}
