using Microsoft.AspNetCore.Mvc;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Banner;
using RookieShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IBannerService
{
    Task<ActionResult<PagedResponseDto<BannerDto>>> GetBannerAsync(BannerCriteriaDto bannerCriteriaDto);
    Task<ActionResult<BannerDto>> GetBannerAsyncById(int id);

}
