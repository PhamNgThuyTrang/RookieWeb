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

namespace Rookie.CustomerSite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public ProductsController(
            IProductService productService,
            IConfiguration configuration,
            IMapper mapper
            )
        {
            _productService = productService;
            _config = configuration;
            _mapper = mapper;
        }

        public async Task<ActionResult<PagedResponseVM<ProductVm>>> ProductByCategory(int subcategoryId, string search)
        {
            var productCriteriaDto = new ProductCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };

            if (!String.IsNullOrEmpty(search))
            {
                productCriteriaDto.Search = search;
                ViewBag.Search = search;
            }
            var pagedProducts = await _productService.GetProductAsyncByCategory(subcategoryId, productCriteriaDto);
            var productsVm = _mapper.Map<PagedResponseVM<ProductVm>>(pagedProducts);
            return View(productsVm);
        }
    }
}
