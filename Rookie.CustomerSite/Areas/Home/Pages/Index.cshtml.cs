using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Banner;
using Rookie.CustomerSite.ViewModel.Product;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Banner;
using RookieShop.Shared.Dto.Product;
using RookieShop.Shared.Enum;

namespace Rookie.CustomerSite.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly IBannerService _bannerService;
        private readonly IProductService _productService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IndexModel(
            IBannerService bannerService,
            IProductService productService,
            IConfiguration config,
            IMapper mapper)
        {
            _bannerService = bannerService;
            _productService = productService;
            _config = config;
            _mapper = mapper;
        }

        public PagedResponseVM<BannerVm> Banners { get; set; }
        public PagedResponseVM<ProductVm> Products { get; set; }

        public async Task OnGetAsync()
        {
            var bannerCriteriaDto = new BannerCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedbanners = await _bannerService.GetBannerAsync(bannerCriteriaDto);
            Banners = _mapper.Map<PagedResponseVM<BannerVm>>(pagedbanners);

            var productCriteriaDto = new ProductCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedProducts = await _productService.GetProductAsync(productCriteriaDto);
            Products = _mapper.Map<PagedResponseVM<ProductVm>>(pagedProducts);
        }
    }
}
