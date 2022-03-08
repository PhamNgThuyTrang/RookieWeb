using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Product;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Product;
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
        public string Search { get; set; }

        public async Task OnGetAsync(int subcategoryId, string search)
        {
            var productCriteriaDto = new ProductCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };

            if (!String.IsNullOrEmpty(search))
            {
                productCriteriaDto.Search = search;
                Search = search;
            }
            var pagedProducts = await _productService.GetProductAsyncByCategory(subcategoryId, productCriteriaDto);
            Products = _mapper.Map<PagedResponseVM<ProductVm>>(pagedProducts);
        }
    }
}
