using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Category;
using Rookie.CustomerSite.ViewModel.SubCategory;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Category;
using RookieShop.Shared.Dto.SubCategory;
using RookieShop.Shared.Enum;

namespace Rookie.CustomerSite.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public CategoryViewComponent(
            ICategoryService categoryService,
            IConfiguration config,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _config = config;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? category)
        {
            var categoryCriteriaDto = new CategoryCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedCategories = await _categoryService.GetCategoryAsync(categoryCriteriaDto);
            var categories = _mapper.Map<PagedResponseVM<CategoryVm>>(pagedCategories);

            var subCategoryCriteriaDto = new SubCategoryCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var subCategories = await _subCategoryService.GetSubCategoryAsync(subCategoryCriteriaDto);

            foreach (var item in subCategories.Items)
            {
                var index = item.CategoryId;
                //categories.Items[index].
            }
            return View(categories);
        }
    }
}

