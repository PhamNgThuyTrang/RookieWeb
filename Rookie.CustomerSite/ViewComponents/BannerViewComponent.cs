using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Banner;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Banner;
using RookieShop.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IBannerService _bannerService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public BannerViewComponent(
            IBannerService bannerService,
            IConfiguration config,
            IMapper mapper)
        {
            _bannerService = bannerService;
            _config = config;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bannerCriteriaDto = new BannerCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedbanners = await _bannerService.GetBannerAsync(bannerCriteriaDto);
            var banners = _mapper.Map<PagedResponseVM<BannerVm>>(pagedbanners);
            return View(banners);
        }
    }
}
