using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Product;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Product;
using RookieShop.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewComponents
{
    public class NewArrivalViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public NewArrivalViewComponent(
            IProductService productService,
            IConfiguration config,
            IMapper mapper
            )
        {
            _productService = productService;
            _config = config;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync ()
        {
            var productCriteriaDto = new ProductCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedProducts = await _productService.GetProductAsync(productCriteriaDto);
            var products = _mapper.Map<PagedResponseVM<ProductVm>>(pagedProducts);

            return View(products);
        }
    }
}
