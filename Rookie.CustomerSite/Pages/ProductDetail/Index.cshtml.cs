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
using RookieShop.Shared.Enum;

namespace Rookie.CustomerSite.Pages.ProductDetail
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IndexModel(
            IProductService productService,
            IConfiguration config,
            IMapper mapper)
        {
            _productService = productService;
            _config = config;
            _mapper = mapper;
        }
        public ProductVm Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDto = await _productService.GetProductAsyncById(id);
            if (productDto == null)
            {
                return NotFound();
            }

            Product = _mapper.Map<ProductVm>(productDto);
            return Page();
        }
    }
}
