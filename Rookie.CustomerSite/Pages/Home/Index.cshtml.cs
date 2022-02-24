using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Banner;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto.Banner;
using RookieShop.Shared.Enum;

namespace Rookie.CustomerSite.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly IBannerService _bannerService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IndexModel(
            IBannerService bannerService,
            IConfiguration config,
            IMapper mapper)
        {
            _bannerService = bannerService;
            _config = config;
            _mapper = mapper;
        }
        public PagedResponseVM<BannerVm> Banners { get; set; }

        public async Task OnGetAsync()
        {
            var bannerCriteriaDto = new BannerCriteriaDto()
            {
                SortOrder = SortOrderEnum.Accsending,
                Limit = int.Parse(_config[ConfigurationConstants.PAGING_LIMIT])
            };
            var pagedbanners = await _bannerService.GetBannerAsync(bannerCriteriaDto);
            Banners = _mapper.Map<PagedResponseVM<BannerVm>>(pagedbanners);
        }
    }
}
