using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Category;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Category;
using RookieShop.Shared.Dto.SubCategory;
using RookieShop.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewComponents
{
    public class CategoryFooterViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public CategoryFooterViewComponent(
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            IConfiguration config,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _config = config;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryCriteriaDto = new CategoryCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedCategories = await _categoryService.GetCategoryAsync(categoryCriteriaDto);
            var categories = _mapper.Map<PagedResponseVM<CategoryVm>>(pagedCategories);
            return View(categories);
        }
    }
}
