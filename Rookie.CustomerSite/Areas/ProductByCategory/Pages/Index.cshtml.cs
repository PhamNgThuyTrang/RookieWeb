using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Product;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Product;
using RookieShop.Shared.Dto.ProductModel;
using RookieShop.Shared.Enum;

namespace Rookie.CustomerSite.Areas.ProductByCategory.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly IProductService _productService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IndexModel(
            IProductService productService,
            IConfiguration configuration,
            IMapper mapper
            )
        {
            _productService = productService;
            _config = configuration;
            _mapper = mapper;
        }

        public PagedResponseVM<ProductVm> Products { get; set; }

        public async Task OnGetAsync(int subcategoryId)
        {
            var productModelCriteriaDto = new ProductModelCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedProducts = await _productService.GetProductsBySubCategoryId(subcategoryId);
            Products = _mapper.Map<PagedResponseVM<ProductVm>>(pagedProducts);
        }
    }
}
